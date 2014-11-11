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
    public partial class Form1 : Form
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Form1" /> class.
        /// </summary>
        public Form1()
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
            this.Invoke(new EventHandler(delegate { this.listBox1.Items.Remove(licenseKey); }));
        }

        /// <summary>
        /// The online.
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        private void Online(string licenseKey)
        {
            this.Invoke(new EventHandler(delegate { this.listBox1.Items.Add(licenseKey); }));
        }

        /// <summary>
        /// The button 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button1_Click(object sender, EventArgs e)
        {
            ClientPool.OnlineEvent = this.Online;
            ClientPool.OfflineEvent = this.Offline;

            var tcp = new TcpServer(Convert.ToInt32(this.textBox2.Text));
            this.button1.Enabled = false;
            this.checkBox1.Enabled = false;
            tcp.Start();
            if (this.checkBox1.Checked)
            {
                this.timer1.Interval = 5000;
                this.timer1.Enabled = true;
            }
        }

        /// <summary>
        /// The button 2_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a client");
                return;
            }

            string licenseKey = this.listBox1.SelectedItem.ToString();
            if (licenseKey != string.Empty)
            {
                var client = ClientPool.GetClient(licenseKey);
                if (client != null)
                {
                    if (client.Send(this.textBox1.Text))
                    {
                        this.listBox2.Items.Add("TO " + client.LicenseKey + ": " + this.textBox1.Text);
                        this.textBox1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("The client is not alive!");
                }
            }
        }

        /// <summary>
        /// The button 3_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button3_Click(object sender, EventArgs e)
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