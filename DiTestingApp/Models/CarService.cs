namespace DiTestingApp.Models
{
    /// <summary>
    /// Car service
    /// </summary>
    public class CarService : ICarService
    {
        private readonly IVehicleService _vehicleService;

        /// <summary>
        /// IVehicle service is the dependency
        /// </summary>
        /// <param name="vehicleService"></param>
        public CarService(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// go to destination
        /// </summary>
        public void GoToDestination()
        {
            _vehicleService.Drive();
        }
    }
}