using Common.Logging;

namespace Testing.Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class HelloService : IHelloService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HelloWorldJob));
        private static long serviceId;
        private long id;
        public HelloService()
        {
            ++serviceId;
            id = serviceId;
            Log.Info(string.Format("Created HelloService instance [{0}]", id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetHello(string from)
        {
            return string.Format("Hello World! from {0}", from);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Log.Info(string.Format("Disposed HelloService instance [{0}]", id));
        }
    }
}
