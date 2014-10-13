// -----------------------------------------------------------------------
// <copyright file="LogItem.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.Model
{
    using System;

    /// <summary>
    /// the model of log item.
    /// </summary>
    public class LogItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int TaskId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// created date time.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}