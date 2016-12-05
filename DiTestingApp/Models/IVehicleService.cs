namespace DiTestingApp.Models
{
    /// <summary>
    /// Vehicle Service
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// vehicle type
        /// </summary>
        string VehicleType { get; set; }

        /// <summary>
        /// show diagnostics
        /// </summary>
        void ShowDiagnostics();

        /// <summary>
        /// start driving
        /// </summary>
        void Drive();
    }
}