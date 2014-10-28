// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadConfigBody.cs" company="Demandforce">
//      Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   request body of uri: config/upload
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    ///     request body of uri: config/upload
    /// </summary>
    public class UploadConfigBody
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the business credentials.
        /// </summary>
        public BusinessCredentials BusinessCredentials { get; set; }

        /// <summary>
        ///     Gets or sets the config content.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file content.
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        #endregion
    }
}