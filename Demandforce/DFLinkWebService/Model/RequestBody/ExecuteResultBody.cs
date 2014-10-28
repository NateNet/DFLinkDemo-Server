// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecuteResultBody.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   request body of url: "task/executeresult"
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    ///     request body of url: "task/executeresult"
    /// </summary>
    public class ExecuteResultBody
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExecuteResultBody" /> class.
        /// </summary>
        public ExecuteResultBody()
        {
            this.TaskId = -1;
            this.Status = -1;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the business credentials.
        /// </summary>
        public BusinessCredentials BusinessCredentials { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///     Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        #endregion
    }
}