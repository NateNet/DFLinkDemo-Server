// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogController.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The log controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Demandforce.DFLinkServer.BLL;
    using Demandforce.DFLinkServer.Model;
    using Demandforce.DFLinkServer.Model.RequestBody;

    #endregion

    /// <summary>
    ///     The log controller.
    /// </summary>
    public class LogController : ApiController
    {
        #region Public Methods and Operators

        /// <summary>
        /// download all log of a task
        /// </summary>
        /// <param name="requestBody">
        /// the content that post from client
        /// </param>
        /// <returns>
        /// The list of LogItem 
        /// </returns>
        [HttpPost]
        public IList<LogItem> Download([FromBody] LogDownloadBody requestBody)
        {
            // TODO:
            try
            {
                var log = new Log();
                return log.GetLogs(requestBody.TaskId, requestBody.BusinessCredentials.LicenseKey);
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// upload a log
        /// </summary>
        /// <param name="requestBody">
        /// the content post from client
        /// </param>
        /// <returns>
        /// 1: succeeded, 0: failed
        /// </returns>
        [HttpPost]
        public string Upload([FromBody] LogUploadBody requestBody)
        {
            // TODO:
            try
            {
                var logItem = new LogItem { TaskId = requestBody.TaskId, Message = requestBody.Message };

                var log = new Log();
                if (log.Upload(logItem, requestBody.BusinessCredentials.LicenseKey))
                {
                    return "1";
                }

                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
    }
}