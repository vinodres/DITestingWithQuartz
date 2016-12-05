using System.Reflection;
using Common.Logging;

namespace DiTestingApp.Models
{
    /// <summary>
    /// Engine Diagnostics Service
    /// </summary>
    public class EngineDiagnosticsService : IEngineDiagnosticsService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Capture Diagnostics
        /// </summary>
        public void CaptureDiagnostics()
        {
            Log.Info("Capturing diagnostics");
        }
    }
}