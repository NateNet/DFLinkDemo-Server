// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusUpdateBody.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   request body of url: "task/updatestatus"
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    ///     request body of url: "task/updatestatus"
    /// </summary>
    public class StatusUpdateBody
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="StatusUpdateBody" /> class.
        /// </summary>
        public StatusUpdateBody()
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