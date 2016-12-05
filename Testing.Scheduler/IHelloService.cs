using System;

namespace Testing.Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHelloService : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        string GetHello(string from);

    }
}
