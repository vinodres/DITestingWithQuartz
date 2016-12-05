using System;
using Microsoft.Practices.Unity;
using Quartz;
using Testing.Scheduler;

namespace DiTestingApp
{
    /// <summary>
    /// Register types
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="disposableLifetimeManager"></param>
        /// <returns></returns>
        public static IUnityContainer Configure(this IUnityContainer container, Func<LifetimeManager> disposableLifetimeManager )
        {
            
            container.RegisterType<IJob, HelloWorldJob>();
            container.RegisterType<IHelloService, HelloService>(disposableLifetimeManager());
            return container;
        }
    }
}
