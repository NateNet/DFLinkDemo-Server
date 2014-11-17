// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientPool.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DFPushServer
{
    #region

    using System.Collections;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public static class ClientPool
    {
        #region Static Fields

        /// <summary>
        ///     The client list.
        /// </summary>
        private static readonly Hashtable ClientList = new Hashtable();

        #endregion

        #region Delegates

        /// <summary>
        ///     The on offline event.
        /// </summary>
        /// <param name="licenseKey">
        ///     The license key.
        /// </param>
        public delegate void OnOfflineEvent(string licenseKey);

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the client offline.
        /// </summary>
        public static OnOfflineEvent OfflineEvent { get; set; }

        /// <summary>
        ///     Gets or sets the client online.
        /// </summary>
        public static OnOfflineEvent OnlineEvent { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Add a client to client list.
        /// </summary>
        /// <param name="client">
        /// a instance of Client.
        /// </param>
        public static void Add(Client client)
        {
            ClientList.Add(client.LicenseKey, client);
            client.CloseEvent = Remove;
            if (OnlineEvent != null)
            {
                OnlineEvent(client.LicenseKey);
            }
        }

        /// <summary>
        /// Find a client from client list.
        /// </summary>
        /// <param name="licenseKey">
        /// The client license key.
        /// </param>
        /// <returns>
        /// a Client object
        /// </returns>
        public static Client GetClient(string licenseKey)
        {
            var client = (Client)ClientList[licenseKey];
            if (client != null)
            {
                if (client.IsAlive())
                {
                    return client;
                }
                Remove(client.LicenseKey);
            }
            return null;
        }

        /// <summary>
        /// Check the clients in client list are alive or not.
        /// </summary>
        public static void Refresh()
        {
            var closedList = new ArrayList();
            foreach (Client client in ClientList.Values)
            {
                // if (!client.IsAlive())
                if (!client.IsActive())
                {
                    closedList.Add(client.LicenseKey);
                }
            }

            foreach (var licenseKey in closedList)
            {
                Remove(licenseKey.ToString());
            }
        }

        /// <summary>
        /// Remove a client from client list.
        /// </summary>
        /// <param name="licenseKey">
        /// The license key.
        /// </param>
        public static void Remove(string licenseKey)
        {
            var client = (Client)ClientList[licenseKey];
            if (client != null)
            {
                client.Close();
                ClientList.Remove(licenseKey);
            }

            if (OfflineEvent != null)
            {
                OfflineEvent(licenseKey);
            }
        }

        #endregion
    }
}