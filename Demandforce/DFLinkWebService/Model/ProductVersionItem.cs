// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductVersionItem.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//    DO NOT USE
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class ProductVersionItem
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        #endregion
    }
}