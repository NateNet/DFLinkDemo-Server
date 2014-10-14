// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The web API application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API
{
    #region

    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    ///     The web API application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        #region Methods

        /// <summary>
        ///     When application start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        #endregion
    }
}