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

namespace UDPSender
{
    public partial class UDPSender : Form
    {
        private Socket socketUDP;

        private IPAddress ipAddress;
        private int port;
        private IPEndPoint ipEndPoint;

        private int interval;
        private byte[] dataBuffer;

        private int count = 0;

        // SendToAsync
        private bool async = false;
        private SocketAsyncEventArgs socketAsyncEventArgs;
        private Mutex mutex = new Mutex();

        public UDPSender()
        {
            InitializeComponent();
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

                interval = int.Parse(this.TextBoxInterval.Text);
                dataBuffer = Encoding.Default.GetBytes(this.TextBoxData.Text);

                this.TimerSend.Enabled = true;
                this.TimerSend.Interval = interval;
                count = 0;
                this.LabelCount.Text = count.ToString();

                // SendToAsync
                if (async)
                {
                    this.TimerCheck.Interval = interval;

                    socketAsyncEventArgs = new SocketAsyncEventArgs();
                    socketAsyncEventArgs.RemoteEndPoint = ipEndPoint;
                    socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(AsyncCompleted);
                    socketAsyncEventArgs.SetBuffer(dataBuffer, 0, dataBuffer.Length);
                }
            }
            catch (Exception)
            {
                this.TimerSend.Enabled = false;
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            this.TimerSend.Enabled = false;
        }

        private void TimerSend_Tick(object sender, EventArgs e)
        {
            if (!async)
            {
                socketUDP.SendTo(dataBuffer, ipEndPoint);

                ++count;
                this.LabelCount.Text = count.ToString();
            }
            else
            {
                if (!socketUDP.SendToAsync(socketAsyncEventArgs))
                {
                    ++count;
                    this.LabelCount.Text = count.ToString();
                }
            }
        }

        private void AsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.SendTo:
                    ProcessSendToAsync(e);
                    break;
                default:
                    break;
            }
        }

        private void ProcessSendToAsync(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0)
            {
                mutex.WaitOne();

                ++count;

                mutex.ReleaseMutex();
            }
        }

        private void TimerCheck_Tick(object sender, EventArgs e)
        {
            mutex.WaitOne();

            this.LabelCount.Text = count.ToString();

            mutex.ReleaseMutex();
        }

        private void CheckBoxAsync_Click(object sender, EventArgs e)
        {

        }

        private void CheckBoxAsync_CheckedChanged(object sender, EventArgs e)
        {
            async = this.CheckBoxAsync.Checked;
        }
    }
}
