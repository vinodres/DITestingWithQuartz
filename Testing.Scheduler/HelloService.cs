namespace Testing.Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class HelloService : IHelloService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetHello(string from)
        {
            return string.Format("Hello World! from {0}", from);
        }
    }
}
