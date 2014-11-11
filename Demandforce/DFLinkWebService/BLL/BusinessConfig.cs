// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessConfig.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    #region

    using System;

    using Demandforce.DFLinkServer.DALFactory;
    using Demandforce.DFLinkServer.IDAL;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class BusinessConfig
    {
        #region Fields

        /// <summary>
        /// The config dal.
        /// </summary>
        private IBusinessConfig dal = DataAccess.CreateBusinessConfigDAL();

        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        public IBusinessConfig Dal
        {
            get
            {
                return this.dal;
            }

            set
            {
                this.dal = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Save the business config content.
        /// </summary>
        /// <param name="taskId">
        /// task id.
        /// </param>
        /// <param name="licenseKey">
        /// Business license key.
        /// </param>
        /// <param name="configContent">
        /// The content of business config file.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public bool Save(int taskId, string licenseKey, string configContent)
        {
            this.dal.Insert(taskId, licenseKey, configContent, DateTime.Now);
            return true;
        }

        #endregion
    }
}