// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//   
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DFPushServer
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    ///     The form 1.
    /// </summary>
    public partial class frmMain : Form
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="frmMain" /> class.
        /// </summary>
        public frmMain()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The offline.
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        private void Offline(string licenseKey)
        {
            this.Invoke(new EventHandler(delegate { this.lbClientList.Items.Remove(licenseKey); }));
        }

        /// <summary>
        /// The online.
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        private void Online(string licenseKey)
        {
            this.Invoke(new EventHandler(delegate { this.lbClientList.Items.Add(licenseKey); }));
        }

        /// <summary>
        /// Click to start the tcp server.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            ClientPool.OnlineEvent = this.Online;
            ClientPool.OfflineEvent = this.Offline;

            var tcp = new TcpServer(Convert.ToInt32(this.textBox2.Text));
            this.btnStart.Enabled = false;
            this.ckbRefreshByBeat.Enabled = false;
            tcp.Start();
            if (this.ckbRefreshByBeat.Checked)
            {
                this.timer1.Interval = 5000;
                this.timer1.Enabled = true;
            }
        }

        /// <summary>
        /// Click to send a message to client.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.lbClientList.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a client");
                return;
            }

            string licenseKey = this.lbClientList.SelectedItem.ToString();
            if (licenseKey != string.Empty)
            {
                var client = ClientPool.GetClient(licenseKey);
                if (client != null)
                {
                    if (client.Send(this.tbMessage.Text))
                    {
                        this.lbMessageList.Items.Add("TO " + client.LicenseKey + ": " + this.tbMessage.Text);
                        this.tbMessage.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("The client is not alive!");
                }
            }
        }

        /// <summary>
        /// Click to refresh the client list.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClientPool.Refresh();
        }

        /// <summary>
        /// The timer 1_ tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ClientPool.Refresh();
        }

        #endregion


    }
}