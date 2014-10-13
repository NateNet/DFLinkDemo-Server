// -----------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Demandforce.DFLinkServer.DALFactory
{
    /// <summary>
    /// This class is implemented following the Abstract Factory pattern to create the DAL implementation
    /// </summary>
    public sealed class DataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDAL.ITask CreateTaskDAL()
        {
            return new DAL.Task();
            //return (IDAL.ITask)Assembly.Load("DAL").CreateInstance("Task");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IDAL.ILog CreateLogDAL()
        {
            return new DAL.Log();
            //return (IDAL.ILog)Assembly.Load("DAL").CreateInstance("Log");
        }
    }
}