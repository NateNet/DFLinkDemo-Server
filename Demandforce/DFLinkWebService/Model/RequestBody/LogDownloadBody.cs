// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogDownloadBody.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   request body of uri: log/download
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    ///     request body of uri: log/download
    /// </summary>
    public class LogDownloadBody
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the business credentials.
        /// </summary>
        public BusinessCredentials BusinessCredentials { get; set; }

        /// <summary>
        ///     Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        #endregion
    }
}