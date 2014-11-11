// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessCredentials.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   business identity information
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    ///     business identity information
    /// </summary>
    public class BusinessCredentials
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the license key.
        /// </summary>
        public string LicenseKey { get; set; }

        #endregion
    }
}