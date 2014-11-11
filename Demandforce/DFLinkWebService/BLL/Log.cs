// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="Demandforce">
//   Copyright (c) Demandforce. All rights reserved.
// </copyright>
// <summary>
//   The business component to manage logs
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.BLL
{
    #region

    using System.Collections.Generic;

    using Demandforce.DFLinkServer.DALFactory;
    using Demandforce.DFLinkServer.IDAL;
    using Demandforce.DFLinkServer.Model;

    #endregion

    /// <summary>
    ///     The business component to manage logs
    /// </summary>
    public class Log
    {
        #region Fields

        /// <summary>
        ///     Get an instance of the Log DAL using DALFactory.
        /// </summary>
        private ILog dal = DataAccess.CreateLogDAL();

        /// <summary>
        /// Gets or sets the dal.
        /// </summary>
        public ILog Dal 
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
        /// Get the log list by a task id.
        /// </summary>
        /// <param name="taskId">
        /// task id
        /// </param>
        /// <param name="licenseKey">
        /// business license key
        /// </param>
        /// <returns>
        /// the array list of LogItem
        /// </returns>
        public IList<LogItem> GetLogs(int taskId, string licenseKey)
        {
            return this.dal.GetLogs(taskId, licenseKey);
        }

        /// <summary>
        /// upload log to message.
        /// </summary>
        /// <param name="log">
        /// an instance of LogItem
        /// </param>
        /// <param name="licenseKey">
        /// business license key 
        /// </param>
        /// <returns>
        /// true: succeeded, false: failed.
        /// </returns>
        public bool Upload(LogItem log, string licenseKey)
        {
            return this.dal.Upload(log, licenseKey);
        }

        #endregion
    }
}