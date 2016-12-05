using System.Web.Http;
using Testing.Scheduler;

namespace DiTestingApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GreetingsController : ApiController
    {
        private readonly IHelloService _helloService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helloService"></param>
        public GreetingsController(IHelloService helloService)
        {
            _helloService = helloService;
        }

        /// <summary>
        /// Invoke IHelloService from REST api. IHelloService is registered with unity container owned by asp.net web api dependency resolver using PerRequestLifetimeManager.
        /// IHelloService is also registered with another instance of unity container owned by Owin startup for Quartz scheduled job using HierarchicalLifetimeManager.
        /// When IHelloService is accessed by a Quartz job, it is resolved using HierarchicalLifetimeManager and when IHelloService is accessed via asp.net web api controller, it is resolved using PerRequestLifetimeManager.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_helloService.GetHello("Greetings REST api"));
        }
    }
}
