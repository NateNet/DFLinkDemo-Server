// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessConfig.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.DAL
{
    #region

    using System;
    using Demandforce.DFLinkServer.IDAL;

    #endregion

    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class BusinessConfig : IBusinessConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// Insert a new record to table BusinessConfig.
        /// </summary>
        /// <param name="taskId">
        /// task id.
        /// </param>
        /// <param name="licenseKey">
        /// Business license key.
        /// </param>
        /// <param name="content">
        /// The content of config file on business server.
        /// </param>
        /// <param name="createDate">
        /// The create date of the record.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Insert(int taskId, string licenseKey, string content, DateTime createDate)
        {
            var config = new Data.BusinessConfig
                             {
                                 TaskId = taskId, 
                                 LicenseKey = licenseKey, 
                                 CreateDate = createDate, 
                                 ConfigContent = content
                             };

            using (var dfEnt = new Data.DFLinkSTEntities())
            {
                dfEnt.BusinessConfigs.AddObject(config);
                dfEnt.SaveChanges();
                return true;
            }
        }

        #endregion
    }
}