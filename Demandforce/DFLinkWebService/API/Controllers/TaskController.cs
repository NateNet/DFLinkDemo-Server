// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskController.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The task controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using Demandforce.DFLinkServer.BLL;
    using Demandforce.DFLinkServer.Model;
    using Demandforce.DFLinkServer.Model.RequestBody;

    #endregion

    /// <summary>
    ///     The task controller.
    /// </summary>
    public class TaskController : ApiController
    {
        #region Public Methods and Operators

        /// <summary>
        /// request tasks from server
        /// </summary>
        /// <param name="credentials">
        /// business info
        /// </param>
        /// <returns>
        /// the task list in xml format
        /// </returns>
        [HttpPost]
        public HttpResponseMessage Get([FromBody] BusinessCredentials credentials)
        {
            try
            {
                var task = new Task();
                IList<TaskItem> tasks = task.GetTasks(credentials.LicenseKey);
                return new HttpResponseMessage
                           {
                               Content =
                                   new StringContent(task.ToXml(tasks), Encoding.UTF8, "text/xml")
                           };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage { Content = new StringContent(ex.Message, Encoding.UTF8, "text/xml") };
            }
        }

        /// <summary>
        /// The update status.
        /// </summary>
        /// <param name="requestBody">
        /// The request body. 
        /// </param>
        /// <returns>
        /// 1: succeeded, 0: failed 
        /// </returns>
        [HttpPost]
        public string UpdateStatus([FromBody] StatusUpdateBody requestBody)
        {
            // TODO:
            try
            {
                var task = new Task();
                if (task.UpdateTaskStatus(
                    requestBody.TaskId, 
                    requestBody.Status, 
                    requestBody.BusinessCredentials.LicenseKey))
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