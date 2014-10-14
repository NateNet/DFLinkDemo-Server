// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccess.cs" company="Demandforce">
//   TODO:
// </copyright>
// <summary>
//   This class is implemented following the Abstract Factory pattern to create the DAL implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Demandforce.DFLinkServer.DALFactory
{
    #region

    using Demandforce.DFLinkServer.DAL;
    using Demandforce.DFLinkServer.IDAL;

    #endregion

    /// <summary>
    ///     This class is implemented following the Abstract Factory pattern to create the DAL implementation
    /// </summary>
    public sealed class DataAccess
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Create a instance of ILog in DAL
        /// </summary>
        /// <returns> The <see cref="ILog" />. </returns>
        public static ILog CreateLogDAL()
        {
            return new Log();

            // return (IDAL.ILog)Assembly.Load("DAL").CreateInstance("Log");
        }

        /// <summary> Create a instance of ITask in DAL. </summary>
        /// <returns> The <see cref="ITask" />. </returns>
        public static ITask CreateTaskDAL()
        {
            return new Task();

            // return (IDAL.ITask)Assembly.Load("DAL").CreateInstance("Task");
        }

        #endregion
    }
}