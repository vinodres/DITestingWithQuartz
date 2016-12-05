# How to configure Unity DI With Quartz in ASP.NET Webapi? - demo project
Unity DI Testing With Quartz in ASP.NET Webapi

This sample project demonstrates how to setup Unity DI inside asp.net web api project with Quartz.net job scheduler. IHelloService is a disposable type which must be disposed at the end of each job execution as well as it must be disposed for each http request. 

I have used Quartz.Unity Nuget package https://github.com/hbiarge/Quartz.Unity. I really appreciate the owner of this package. Thank you.

For more information regarding Quartz.Net, please visit http://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/index.html

This sample project is created using Visual Studio 2015 and the asp.net web api test project is setup with .net 4.6.1 framework. For simplicity purposes, types are registered individually instead of using register by convention.

To run this project, please clone it or download and then create an IIS virtual directory pointing to the DITestingApp folder with just Anonymous Authentication enabled. This application writes to log files located at c:\logs\DITesting\, but you can always change the path to a desired location by editing web.config log4net section.

A Quartz job called HelloWorldJob is invoked every 20 secs using Quartz scheduler. Quartz scheduler intitialization is done using Owin startup. HelloWorldJob has a dependency on IHelloService and GetHello method is invoked as part of Job execution. IHelloService is a disposable type.

Two isolated instances of IUnityContainer are maintained. One instance is used by asp.net web api Request/Response pipeline and another instance used by Quartz Owin startup. All the type registrations are maintained by both unity containers. 

Asp.Net web api owned IUnityContainer allows the types to be registered with PerRequestLifetimeManager (optional) and the same types are also registered with IUnityContainer owned by Quartz  Owin startup with HierarchicalLifetimeManager.

This configuration allows for a single type to be added as a dependency into both webapi Controllers as well as Quartz jobs and depending on the execution path, appropriate instance of IUnityContainer helps resolve the dependency.

If you were to use a database context instance such as EF6 IDBContext and want to dispose it along the lines of web api Request/Response, but also like to dispose it at the end of each scheduled job, it is possible with the way Unity is configured in this sample project.

#Dependencies

This project internally uses following dependencies
(Minimum packages required to setup Unity with Quartz and Asp.Net web api)
* Quartz.NET Nuget package https://www.nuget.org/packages/Quartz/
* Quartz.Unity Nuget package and its dependencies https://github.com/hbiarge/Quartz.Unity
* Microsoft.Owin.Host.SystemWeb Nuget package v3.0.1 and its dependencies https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb/
* Unity.AspNet.WebApi v4.0.1 Nuget package and its dependencies
* Unity.Mvc v4.0.1 Nuget package
* WebActivatorEx v2.2.0 Nuget package

#How to test?

As soon as you run the project, a log file is created at c:\logs\DITesting\DITesting.log. Every 20 seconds you start seeing following log entires

> 12-05-2016 13:21:26 DEBUG [2318D, ] Producing instance of Job 'DEFAULT.4eb39ba9-156d-40cf-8a52-7dadc7849557', class=Testing.Scheduler.HelloWorldJob

> 12-05-2016 13:21:26 DEBUG [2318D, ] Batch acquisition of 1 triggers

> 12-05-2016 13:21:26 DEBUG [2318D, ] Calling Execute on job DEFAULT.4eb39ba9-156d-40cf-8a52-7dadc7849557

> 12-05-2016 13:21:26 INFO  [2318D, ] Created HelloService instance [4]

> 12-05-2016 13:21:26 DEBUG [2318D, ] 

> ****

> Job DEFAULT.4eb39ba9-156d-40cf-8a52-7dadc7849557 fired @ Mon, 05 Dec 2016 18:21:26 GMT next scheduled for Mon, 05 Dec 2016 18:21:46 GMT

> ***
> 

> 12-05-2016 13:21:26 DEBUG [2318D, ] 

> ***
> Hello World! from Quartz Job!
> ***
> 
> 12-05-2016 13:21:26 INFO  [2318D, ] Disposed HelloService instance [4]

> 12-05-2016 13:21:26 DEBUG [2318D, ] Trigger instruction : NoInstruction
> 

And if you try to access the http://localhost/DITestingApp/api/Greetings REST end point, you will get following response back 

>> Hello World! from Greetings REST api

followed by these log entries in the log file

> 12-05-2016 13:26:21 INFO  [2318D, ] Created HelloService instance [20]

> 12-05-2016 13:26:21 INFO  [2318D, ] Disposed HelloService instance [20]

