namespace DFPushServer
{
    partial class frmMain
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ckbRefreshByBeat = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbClientList = new System.Windows.Forms.GroupBox();
            this.lbClientList = new System.Windows.Forms.ListBox();
            this.gbMessage = new System.Windows.Forms.GroupBox();
            this.lbMessageList = new System.Windows.Forms.ListBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbClientList.SuspendLayout();
            this.gbMessage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.ckbRefreshByBeat);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 50);
            this.panel1.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(319, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(39, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "9001";
            // 
            // ckbRefreshByBeat
            // 
            this.ckbRefreshByBeat.AutoSize = true;
            this.ckbRefreshByBeat.Location = new System.Drawing.Point(139, 16);
            this.ckbRefreshByBeat.Name = "ckbRefreshByBeat";
            this.ckbRefreshByBeat.Size = new System.Drawing.Size(162, 17);
            this.ckbRefreshByBeat.TabIndex = 9;
            this.ckbRefreshByBeat.Text = "refresh status by client\'s beat";
            this.ckbRefreshByBeat.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(58, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbClientList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbMessage);
            this.splitContainer1.Size = new System.Drawing.Size(867, 462);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 13;
            // 
            // gbClientList
            // 
            this.gbClientList.Controls.Add(this.lbClientList);
            this.gbClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbClientList.Location = new System.Drawing.Point(0, 0);
            this.gbClientList.Name = "gbClientList";
            this.gbClientList.Size = new System.Drawing.Size(253, 462);
            this.gbClientList.TabIndex = 18;
            this.gbClientList.TabStop = false;
            this.gbClientList.Text = "Client list";
            // 
            // lbClientList
            // 
            this.lbClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbClientList.FormattingEnabled = true;
            this.lbClientList.Location = new System.Drawing.Point(3, 16);
            this.lbClientList.Name = "lbClientList";
            this.lbClientList.Size = new System.Drawing.Size(247, 443);
            this.lbClientList.TabIndex = 12;
            // 
            // gbMessage
            // 
            this.gbMessage.Controls.Add(this.lbMessageList);
            this.gbMessage.Controls.Add(this.panel2);
            this.gbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMessage.Location = new System.Drawing.Point(0, 0);
            this.gbMessage.Name = "gbMessage";
            this.gbMessage.Size = new System.Drawing.Size(610, 462);
            this.gbMessage.TabIndex = 17;
            this.gbMessage.TabStop = false;
            this.gbMessage.Text = "Messages";
            // 
            // lbMessageList
            // 
            this.lbMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessageList.FormattingEnabled = true;
            this.lbMessageList.Location = new System.Drawing.Point(3, 16);
            this.lbMessageList.Name = "lbMessageList";
            this.lbMessageList.Size = new System.Drawing.Size(604, 375);
            this.lbMessageList.TabIndex = 18;
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessage.Location = new System.Drawing.Point(0, 12);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(504, 46);
            this.tbMessage.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbMessage);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 68);
            this.panel2.TabIndex = 17;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.Location = new System.Drawing.Point(515, 21);
            this.btnSend.Margin = new System.Windows.Forms.Padding(5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 29);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 512);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Push Server";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbClientList.ResumeLayout(false);
            this.gbMessage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbRefreshByBeat;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbClientList;
        private System.Windows.Forms.ListBox lbClientList;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.ListBox lbMessageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnSend;
    }
}

