// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DFPushServer
{
    #region

    using System;
    using System.Net.Sockets;
    using System.Text;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class Client
    {
        #region Constants

        /// <summary>
        /// The top 20 bytes, can used to define the size of the data or something else.
        /// NOT USE
        /// </summary>
        private const string DataHead = "00000000000000000000";

        #endregion

        #region Fields

        /// <summary>
        ///     The TCP client.
        /// </summary>
        private TcpClient tcp = new TcpClient();

        /// <summary>
        /// The closed.
        /// </summary>
        private bool closed;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="tcpClient">
        /// The TCP client.
        /// </param>
        /// <param name="licenseKey">
        /// The license Key.
        /// </param>
        public Client(TcpClient tcpClient, string licenseKey)
        {
            this.tcp = tcpClient;
            this.LicenseKey = licenseKey;
            this.LastTime = DateTime.Now;
            this.LastBytes = new byte[this.tcp.ReceiveBufferSize];

            this.tcp.GetStream().BeginRead(this.LastBytes, 0, this.LastBytes.Length, this.ReadCallBack, this.tcp);
        }

        /// <summary>
        /// use the new tcpClient instead the old one.
        /// </summary>
        /// <param name="tcpClient">
        /// the new tcp client.
        /// </param>
        public void UpdateTcpClient(TcpClient tcpClient)
        {
            if (this.tcp != null)
            {
                this.tcp.Close();
            }
            this.tcp = tcpClient;
            this.LastTime = DateTime.Now;
            this.LastBytes = new byte[this.tcp.ReceiveBufferSize];
            this.tcp.GetStream().BeginRead(this.LastBytes, 0, this.LastBytes.Length, this.ReadCallBack, this.tcp);
        }

        #endregion

        #region Delegates

        /// <summary>
        /// The client close event.
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        public delegate void OnCloseEvent(string licenseKey);

        /// <summary>
        /// The receive data event. 
        /// NOT USE
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        /// <param name="bytes">
        /// The bytes.
        /// </param>
        public delegate void OnReceiveDataEvent(string licenseKey, byte[] bytes);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the close event.
        /// </summary>
        public OnCloseEvent CloseEvent { get; set; }

        /// <summary>
        ///     Gets or sets the last message.
        /// </summary>
        public byte[] LastBytes { get; set; }

        /// <summary>
        ///     Gets or sets the last time.
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        ///     Gets or sets the license key.
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        ///     Gets or sets the TCP client.
        /// </summary>
        public TcpClient Tcp { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The close.
        /// </summary>
        public void Close()
        {
            if (this.tcp != null)
            {
                this.tcp.Close();
            }

            this.LicenseKey = null;
            this.LastBytes = null;
        }

        /// <summary>
        ///     Check the client is alive or not
        /// </summary>
        /// <returns>
        ///     boolean: true(alive) or false(not alive)
        /// </returns>
        public bool IsActive()
        {
            /*
            if (this.tcp.GetStream().DataAvailable)
            {
                this.tcp.GetStream().BeginRead(this.LastBytes, 0, this.LastBytes.Length, new AsyncCallback(this.ReadCallBack), this.tcp);
            }
            */

            // if no data received from a client for 30 seconds, means the client is offline
            if ((DateTime.Now - this.LastTime).TotalSeconds > 30)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Another function that check the client is alive or not. But not use.
        /// NOT USE
        /// </summary>
        /// <returns>
        /// Boolean: true(alive), false(not alive).
        /// </returns>
        public bool IsAlive()
        {
            try
            {
                if (!this.tcp.Connected)
                {
                    return false;
                }

                if (this.tcp.Client.Poll(0, SelectMode.SelectRead))
                {
                    var buff = new byte[1];
                    if (this.tcp.Client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// The call back function when start receive data from client.
        /// </summary>
        /// <param name="ar">
        /// The status of an asynchronous operation.
        /// </param>
        public void ReadCallBack(IAsyncResult ar)
        {
            try
            {
                var tcpClient = (TcpClient)ar.AsyncState;
                if (tcpClient.Connected) // if connected=false, the client is closed by server side.
                {
                    if (tcpClient.GetStream().EndRead(ar) > 0)
                    {
                        this.LastTime = DateTime.Now;
                        tcpClient.GetStream()
                            .BeginRead(this.LastBytes, 0, this.LastBytes.Length, this.ReadCallBack, tcpClient);
                    }
                    else
                    {
                        throw new Exception("0 byte received, client is closed");
                    }
                }
            }
            catch (Exception ex)
            {
                // how to know not in CloseEvent
                if (this.CloseEvent != null)
                {
                    this.CloseEvent(this.LicenseKey);
                }
            }
        }

        /// <summary>
        /// Send a message to client.
        /// </summary>
        /// <param name="str">
        /// The string message you want to send.
        /// </param>
        /// <returns>
        /// true: sent. false: send failed.
        /// </returns>
        public bool Send(string str)
        {
            try
            {
                // str = this.LicenseKey + " - " + str;

                var bytes = this.ToBytes(str);
                var stream = this.tcp.GetStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                this.LastTime = DateTime.Now;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Convert a string to byte array.
        /// </summary>
        /// <param name="str">
        /// The string.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        private byte[] ToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        #endregion
    }
}