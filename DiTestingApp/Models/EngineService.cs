using System.Reflection;
using Common.Logging;

namespace DiTestingApp.Models
{
    /// <summary>
    /// engine service
    /// </summary>
    public class EngineService : IEngineService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        /// <summary>
        /// 
        /// </summary>
        public string EngineModel { get; set; }

        /// <summary>
        /// start the engine
        /// </summary>
        public void Start()
        {
            Log.Info("Run");
        }
    }
}