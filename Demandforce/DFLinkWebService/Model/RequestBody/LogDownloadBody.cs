// -----------------------------------------------------------------------
// <copyright file="LogDownloadBody.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    /// request body of uri: log/download
    /// </summary>
    public class LogDownloadBody
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessCredentials BusinessCredentials { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int TaskId { get; set; }
    }
}