using System;
using Common.Logging;
using Quartz;

namespace Testing.Scheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class HelloWorldJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HelloWorldJob));

        private readonly IHelloService _helloService;

        /// <summary> 
        /// constructor for job initilization
        /// Inject any services that this job depends on.
        /// </summary>
        public HelloWorldJob(IHelloService helloService)
        {
            _helloService = helloService;
        }

        /// <summary>
        /// Invoke IHelloService from HelloWorldJob scheduled using Quartz.net. 
        /// IHelloService is registered with another instance of unity container owned by Owin startup for Quartz scheduled job using HierarchicalLifetimeManager.
        /// IHelloService is also registered with unity container owned by asp.net web api dependency resolver using PerRequestLifetimeManager.
        /// When IHelloService is accessed by a Quartz job, it is resolved using HierarchicalLifetimeManager and when IHelloService is accessed via asp.net web api controller, it is resolved using PerRequestLifetimeManager.
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                Log.DebugFormat("{0}****{0}Job {1} fired @ {2} next scheduled for {3}{0}***{0}",
                                                                        Environment.NewLine,
                                                                        context.JobDetail.Key,
                                                                        context.FireTimeUtc.Value.ToString("r"),
                                                                        context.NextFireTimeUtc.Value.ToString("r"));


                Log.DebugFormat("{0}***{0}{1}!{0}***{0}", Environment.NewLine, _helloService.GetHello("Quartz Job"));
            }
            catch (Exception ex)
            {
                Log.DebugFormat("{0}***{0}Failed: {1}{0}***{0}", Environment.NewLine, ex.Message);
            }
        }
    }
}
