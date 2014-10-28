// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigController.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   The config on business server controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API.Controllers
{
    #region

    using System;
    using System.Text;
    using System.Web.Http;
    using Demandforce.DFLinkServer.BLL;
    using Demandforce.DFLinkServer.Model.RequestBody;

    #endregion

    /// <summary>
    ///     The controller of config on business server.
    /// </summary>
    public class ConfigController : ApiController
    {
        /// <summary>
        /// upload business config
        /// </summary>
        /// <param name="requestBody">
        /// The request body when upload business config.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [HttpPost]
        public string Upload([FromBody] UploadConfigBody requestBody)
        {
            try
            {
                var config = new BusinessConfig();
                if (config.Save(
                    requestBody.TaskId,
                    requestBody.BusinessCredentials.LicenseKey,
                    Encoding.UTF8.GetString(Convert.FromBase64String(requestBody.FileContent))))
                {
                    return "1";
                }
                else
                {
                    return "0"; 
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}