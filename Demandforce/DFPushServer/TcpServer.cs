// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TcpServer.cs" company="Demandforce">
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
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class TcpServer
    {
        #region Fields

        /// <summary>
        ///     The TCP listener.
        /// </summary>
        private readonly TcpListener tcpListener;


        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServer"/> class.
        /// </summary>
        /// <param name="listenPort">
        /// The license port.
        /// </param>
        public TcpServer(int listenPort)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, listenPort);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.tcpListener.Start();
            this.tcpListener.BeginAcceptTcpClient(this.AcceptClient, this.tcpListener);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The accept client.
        /// </summary>
        /// <param name="ar">
        /// The status of an asynchronous operation.
        /// </param>
        private void AcceptClient(IAsyncResult ar)
        {
            this.tcpListener.BeginAcceptTcpClient(this.AcceptClient, this.tcpListener);

            var server = (TcpListener)ar.AsyncState;
            var client = server.EndAcceptTcpClient(ar);
            try
            {
                var stream = client.GetStream();
                var bytes = new byte[50];

                // try to read the license key in 2 seconds.
                stream.ReadTimeout = 2000;
                stream.Read(bytes, 0, 50);

                var licenseKey = Encoding.UTF8.GetString(bytes).TrimEnd('\0');
                if (licenseKey != string.Empty)
                {
                    var existClient = ClientPool.GetClient(licenseKey);
                    if (existClient == null)
                    {
                        var c = new Client(client, licenseKey);
                        ClientPool.Add(c);
                    }
                    else
                    {
                        existClient.UpdateTcpClient(client);
                    }
                }
                else
                {
                    client.Close();
                }
            }
            catch
            {
                client.Close();
            }
        }

        #endregion
    }
}