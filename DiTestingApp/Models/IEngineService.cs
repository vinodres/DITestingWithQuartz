namespace DiTestingApp.Models
{
    /// <summary>
    /// Engine Service
    /// </summary>
    public interface IEngineService
    {
        /// <summary>
        /// 
        /// </summary>
        string EngineModel { get; set; }

        /// <summary>
        /// start
        /// </summary>
        void Start();
    }
}