// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductVersion.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   DO NOT USE NOW
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.IDAL
{
    #region

    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public interface IProductVersion
    {
        #region Public Methods and Operators

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="item">
        /// The product info.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Insert(ProductVersionItem item);

        #endregion
    }
}