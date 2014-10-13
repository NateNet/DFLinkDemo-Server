// -----------------------------------------------------------------------
// <copyright file="StatusUpdateBody.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    /// request body of uri: log/status/update
    /// </summary>
    public class StatusUpdateBody
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessCredentials BusinessCredentials { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }

        public StatusUpdateBody()
        {
            this.TaskId = -1;
            this.Status = -1;

        }
    }
}