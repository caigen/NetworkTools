namespace UDPReceiver
{
    partial class UDPReceiver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CheckBoxAsync = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelCount = new System.Windows.Forms.Label();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.TextBoxData = new System.Windows.Forms.TextBox();
            this.TimerReceive = new System.Windows.Forms.Timer(this.components);
            this.TimerCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CheckBoxAsync
            // 
            this.CheckBoxAsync.AutoSize = true;
            this.CheckBoxAsync.Location = new System.Drawing.Point(159, 236);
            this.CheckBoxAsync.Name = "CheckBoxAsync";
            this.CheckBoxAsync.Size = new System.Drawing.Size(54, 16);
            this.CheckBoxAsync.TabIndex = 25;
            this.CheckBoxAsync.Text = "Async";
            this.CheckBoxAsync.UseVisualStyleBackColor = true;
            this.CheckBoxAsync.CheckedChanged += new System.EventHandler(this.CheckBoxAsync_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "Received:";
            // 
            // LabelCount
            // 
            this.LabelCount.AutoSize = true;
            this.LabelCount.Location = new System.Drawing.Point(76, 241);
            this.LabelCount.Name = "LabelCount";
            this.LabelCount.Size = new System.Drawing.Size(11, 12);
            this.LabelCount.TabIndex = 23;
            this.LabelCount.Text = "0";
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(244, 204);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 22;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Data:";
            // 
            // TextBoxInterval
            // 
            this.TextBoxInterval.Location = new System.Drawing.Point(244, 24);
            this.TextBoxInterval.Name = "TextBoxInterval";
            this.TextBoxInterval.Size = new System.Drawing.Size(87, 21);
            this.TextBoxInterval.TabIndex = 20;
            this.TextBoxInterval.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "Interval: (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP:";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(159, 24);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(66, 21);
            this.TextBoxPort.TabIndex = 16;
            this.TextBoxPort.Text = "10111";
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Location = new System.Drawing.Point(11, 24);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(129, 21);
            this.TextBoxIP.TabIndex = 15;
            this.TextBoxIP.Text = "127.0.0.1";
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(9, 204);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 14;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // TextBoxData
            // 
            this.TextBoxData.Location = new System.Drawing.Point(9, 76);
            this.TextBoxData.Multiline = true;
            this.TextBoxData.Name = "TextBoxData";
            this.TextBoxData.ReadOnly = true;
            this.TextBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxData.Size = new System.Drawing.Size(316, 113);
            this.TextBoxData.TabIndex = 13;
            this.TextBoxData.Text = "Hello World!";
            // 
            // TimerReceive
            // 
            this.TimerReceive.Tick += new System.EventHandler(this.TimerReceive_Tick);
            // 
            // TimerCheck
            // 
            this.TimerCheck.Enabled = true;
            this.TimerCheck.Tick += new System.EventHandler(this.TimerCheck_Tick);
            // 
            // UDPReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 262);
            this.Controls.Add(this.CheckBoxAsync);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LabelCount);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBoxInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPort);
            this.Controls.Add(this.TextBoxIP);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.TextBoxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UDPReceiver";
            this.Text = "UDPReceiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxAsync;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LabelCount;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.TextBox TextBoxData;
        private System.Windows.Forms.Timer TimerReceive;
        private System.Windows.Forms.Timer TimerCheck;
    }
}

