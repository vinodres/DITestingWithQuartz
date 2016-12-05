using System.Diagnostics;
using System.Reflection;
using Common.Logging;

namespace DiTestingApp.Models
{
    /// <summary>
    /// Vehicle Service
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IEngineService _engineService;
        private readonly IEngineDiagnosticsService _diagnosticsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engineService"></param>
        /// <param name="diagnosticsService"></param>
        public VehicleService(IEngineService engineService, IEngineDiagnosticsService diagnosticsService)
        {
            _engineService = engineService;
            _diagnosticsService = diagnosticsService;
        }

        /// <summary>
        /// 
        /// </summary>
        public string VehicleType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void ShowDiagnostics()
        {
            _engineService.Start();
            _diagnosticsService?.CaptureDiagnostics();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Drive()
        {
            _engineService.Start();
            Log.Info("Started driving");
        }
    }
}