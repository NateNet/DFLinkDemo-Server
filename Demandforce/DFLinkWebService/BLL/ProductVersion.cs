// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductVersion.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    #region

    using Demandforce.DFLinkServer.DALFactory;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     DO NOT USE NOW.
    /// </summary>
    public class ProductVersion
    {
        #region Fields

        /// <summary>
        /// The data access object.
        /// </summary>
        private readonly IProductVersion dao = DataAccess.CreateProductVersionDAL();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Save product version info.  
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Save(ProductVersionItem item)
        {
            this.dao.Insert(item);
            return true;
        }

        #endregion
    }
}