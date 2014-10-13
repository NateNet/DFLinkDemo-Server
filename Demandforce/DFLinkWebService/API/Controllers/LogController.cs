using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demandforce.DFLinkServer.Model;
using Demandforce.DFLinkServer.Model.RequestBody;
using Demandforce.DFLinkServer.BLL;

namespace Demandforce.DFLinkServer.API.Controllers
{
    public class LogController : ApiController
    {
        /// <summary>
        /// upload a log
        /// </summary>
        /// <param name="requestBody">the content post from client</param>
        /// <returns></returns>
        [HttpPost]
        public string Upload([FromBody]LogUploadBody requestBody)
        {
            // TODO:
            try
            {
                var logItem = new LogItem()
                {
                    TaskId = requestBody.TaskId,
                    Message = requestBody.Message
                };

                BLL.Log log = new Log();
                if (log.Upload(logItem, requestBody.BusinessCredentials.LicenseKey))
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// download all log of a task
        /// </summary>
        /// <param name="requestBody">the content that post from client</param>
        /// <returns></returns>
        [HttpPost]
        public IList<LogItem> Download([FromBody]LogDownloadBody requestBody)
        {
            // TODO:
            try
            {
                BLL.Log log = new Log();
                return log.GetLogs(requestBody.TaskId, requestBody.BusinessCredentials.LicenseKey);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}
