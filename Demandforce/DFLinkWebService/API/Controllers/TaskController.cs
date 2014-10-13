using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demandforce.DFLinkServer.Model.RequestBody;
using Demandforce.DFLinkServer.Model;
using Demandforce.DFLinkServer.BLL;
using System.Text;

namespace Demandforce.DFLinkServer.API.Controllers
{
    public class TaskController : ApiController
    {
        /// <summary>
        /// request tasks from server
        /// </summary>
        /// <param name="credentials">business info</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get([FromBody]BusinessCredentials credentials)
        {
            try
            {
                BLL.Task task = new BLL.Task();
                IList<TaskItem> tasks = task.GetTasks(credentials.LicenseKey);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(
                        task.ToXml(tasks),
                        Encoding.UTF8,
                        "text/xml"
                    )
                };
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(
                        ex.Message,
                        Encoding.UTF8,
                        "text/xml"
                    )
                };
            }
        }

        [HttpPost]
        public string UpdateStatus([FromBody]StatusUpdateBody requestBody)
        {
            // TODO:
            try
            {
                BLL.Task task = new Task();
                if (task.UpdateTaskStatus(requestBody.TaskId, requestBody.Status, requestBody.BusinessCredentials.LicenseKey))
                    return "1";
                else
                    return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        // GET api/task
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/task
        public void Post([FromBody]string value)
        {
        }

        // PUT api/task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/task/5
        public void Delete(int id)
        {
        }
    }
}
