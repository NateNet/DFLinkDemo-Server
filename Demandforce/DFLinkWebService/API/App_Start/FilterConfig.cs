// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   The filter config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.API
{
    #region

    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The filter config.
    /// </summary>
    public class FilterConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}