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

namespace UDPSender
{
    public partial class UDPSender : Form
    {
        private IPAddress ipAddress;
        private int port;
        private int interval;
        private IPEndPoint ipEndPoint;

        private Socket socketUDP;
        private byte[] dataBuffer;
        
        public UDPSender()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                ipAddress = IPAddress.Parse(this.TextBoxIP.Text);
                port = int.Parse(this.TextBoxPort.Text);
                interval = int.Parse(this.TextBoxInterval.Text);
                ipEndPoint = new IPEndPoint(ipAddress, port);

                socketUDP = new Socket(ipEndPoint.AddressFamily,
                    SocketType.Dgram, ProtocolType.Udp);

                dataBuffer = Encoding.Default.GetBytes(this.TextBoxData.Text);

                this.TimerSend.Enabled = true;
                this.TimerSend.Interval = interval;
                this.LabelCount.Text = "0";
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
            socketUDP.SendTo(dataBuffer, ipEndPoint);
            int count = int.Parse(this.LabelCount.Text) + 1;
            this.LabelCount.Text = count.ToString();
        }
    }
}
