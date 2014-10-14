// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The web api config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API
{
    #region

    using System.Web.Http;

    #endregion

    /// <summary>
    /// The web API config.
    /// </summary>
    public static class WebApiConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }

        #endregion
    }
}