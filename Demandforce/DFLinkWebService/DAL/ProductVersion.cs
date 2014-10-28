// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductVersion.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   DO NOT USE NOW
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.DAL
{
    #region
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class ProductVersion : IProductVersion
    {
        #region Public Methods and Operators

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Insert(ProductVersionItem item)
        {
            var prod = new Data.ProductVersion
                                           {
                                               TaskId = item.TaskId, 
                                               FileName = item.FileName, 
                                               Version = item.Version, 
                                               LicenseKey = item.LicenseKey
                                           };
            using (var dfEnt = new Data.DFLinkSTEntities())
            {
                dfEnt.ProductVersions.AddObject(prod);
                dfEnt.SaveChanges();
                return true;
            }
        }

        #endregion
    }
}