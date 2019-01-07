using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDPReceiver
{
    public partial class UDPReceiver : Form
    {
        private Socket socketUDP;
        
        private IPAddress ipAddress;
        private int port;
        private IPEndPoint ipEndPoint;

        private int interval;
        private byte[] dataBuffer;

        private int count = 0;

        // ReceiveFromAsync
        private bool async = false;
        private SocketAsyncEventArgs socketAsyncEventArgs;
        private Mutex mutex = new Mutex();
        private byte[] logicBuffer;
        private int logicBufferUsedSize;
        
        public UDPReceiver()
        {
            InitializeComponent();
        }

        private void TimerReceive_Tick(object sender, EventArgs e)
        {
            if (!async)
            {
                // Poll first to avoid blocking the main thread.
                if (socketUDP.Poll(1, SelectMode.SelectRead))
                {
                    EndPoint endPoint = (EndPoint)ipEndPoint;
                    int size = socketUDP.ReceiveFrom(dataBuffer, ref endPoint);
                    if (size > 0)
                    {
                        string data = Encoding.Default.GetString(dataBuffer);
                        this.TextBoxData.AppendText(data);
                        this.TextBoxData.AppendText("\r\n");
                        this.TextBoxData.ScrollToCaret();

                        ++count;
                        this.LabelCount.Text = count.ToString();
                    }
                }
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                socketUDP = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                ipAddress = IPAddress.Parse(this.TextBoxIP.Text);
                port = int.Parse(this.TextBoxPort.Text);
                ipEndPoint = new IPEndPoint(ipAddress, port);

                // Receive needs Bind.
                socketUDP.Bind(ipEndPoint);

                interval = int.Parse(this.TextBoxInterval.Text);
                dataBuffer = new byte[1024];
                
                count = 0;
                this.LabelCount.Text = count.ToString();

                this.TextBoxData.Clear();
                this.ButtonStart.Enabled = false;

                // ReceiveFromAsync
                if (async)
                {
                    logicBuffer = new byte[2048];
                    logicBufferUsedSize = 0;

                    socketAsyncEventArgs = new SocketAsyncEventArgs();
                    socketAsyncEventArgs.RemoteEndPoint = ipEndPoint;
                    socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(AsyncCompleted);
                    socketAsyncEventArgs.SetBuffer(dataBuffer, 0, dataBuffer.Length);

                    this.TimerCheck.Interval = interval;

                    TryReceive(socketAsyncEventArgs);
                }
                else
                {
                    this.TimerReceive.Enabled = true;
                    this.TimerReceive.Interval = interval;
                }
            }
            catch (Exception exception)
            {
                this.TimerReceive.Enabled = false;

                this.TextBoxData.Text = exception.Message.ToString();
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            this.TimerReceive.Enabled = false;

            // Bound socket must be closed before reuse the port.
            socketUDP.Close();

            this.ButtonStart.Enabled = true;
        }

        private void CheckBoxAsync_CheckedChanged(object sender, EventArgs e)
        {
            async = this.CheckBoxAsync.Checked;
        }

        private void TryReceive(SocketAsyncEventArgs e)
        {
            try
            {
                if (!socketUDP.ReceiveFromAsync(e))
                {
                    ProcessReceive(e);
                }
            }
            catch (Exception)
            {
                // When socket is closed.
            }
        }

        private void AsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.ReceiveFrom:
                    ProcessReceive(e);
                    break;
                default:
                    break;                    
            }

            TryReceive(e);
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0)
            {
                mutex.WaitOne();

                ++count;

                if (e.BytesTransferred < logicBuffer.Length - logicBufferUsedSize)
                {
                    System.Array.Copy(dataBuffer, 0, logicBuffer, logicBufferUsedSize, e.BytesTransferred);
                    logicBufferUsedSize += e.BytesTransferred;
                }

                mutex.ReleaseMutex();
            }
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            mutex.WaitOne();

            this.LabelCount.Text = count.ToString();

            if (logicBufferUsedSize > 0)
            {
                string logicString = Encoding.Default.GetString(logicBuffer);

                this.TextBoxData.AppendText(logicString);
                this.TextBoxData.AppendText("\r\n");
                this.TextBoxData.ScrollToCaret();

                logicBufferUsedSize = 0;
            }

            mutex.ReleaseMutex();
        }
    }
}
