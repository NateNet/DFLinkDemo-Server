// -----------------------------------------------------------------------
// <copyright file="LogUploadBody.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.Model.RequestBody
{
    /// <summary>
    /// request body of uri: log/upload
    /// </summary>
    public class LogUploadBody
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
        public string Message { get; set; }
    }
}