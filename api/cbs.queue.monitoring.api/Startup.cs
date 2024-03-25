using System.Reflection;
using cbs.queue.monitoring.api.Configurations;
using cbs.queue.monitoring.api.Configurations.Installers;
using cbs.queue.monitoring.api.Schedulers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using cbs.queue.monitoring.api.Proxies.WSs;
using cbs.queue.monitoring.api.Proxies.Msmq;

namespace cbs.queue.monitoring.api;

/// <summary>
/// Startup class for configurations
/// </summary>
public class Startup
{
    /// <summary>
    /// Startup ctor
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="hostEnv"></param>
    public Startup(IConfiguration configuration, IWebHostEnvironment hostEnv)
    {
        this.Configuration = configuration;
        this.HostEnv = hostEnv;
    }

    /// <summary>
    /// IConfiguration
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// IWebHostEnvironment
    /// </summary>
    public IWebHostEnvironment HostEnv { get; }

    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAspBasicInstaller();

        services.AddSwaggerInstaller();

        services.AddSerilogInstaller(this.Configuration, this.HostEnv);

        services.AddRoutingVersioningInstaller();

        services.ConfigureInfrastructure();

        services.AddCustomMvc();

        services.AddListStartupServicesInstaller();

        services.AddHttpClient();

        services.AddControllers()
            .AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        services.AddSingleton<IWsConfiguration, WsConfiguration>();
        services.AddSingleton<IMsmqConfiguration, MsmqConfiguration>();

        services.AddSingleton<IJobFactory, JobFactory>();
        services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
        services.AddHostedService<QuartzHostedService>();

        services.AddSingleton<NetLoggingWsInitializerJob>();
        services.AddSingleton<NetNotificationWsInitializerJob>();
        services.AddSingleton<NetAttachmentReceptionWsInitializerJob>();
        services.AddSingleton<NetContentProcessingWsInitializerJob>();
        services.AddSingleton<NetIntegrationWsInitializerJob>();
        services.AddSingleton<NetReceptionWsInitializerJob>();
        services.AddSingleton<NetResolutionWsInitializerJob>();
        services.AddSingleton<NetSchemaValidationWsInitializerJob>();

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetLoggingWsInitializerJob),
            cronExpression: "0/5 * * * * ?")); // run every 5 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetNotificationWsInitializerJob),
            cronExpression: "0/6 * * * * ?")); // run every 6 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetAttachmentReceptionWsInitializerJob),
            cronExpression: "0/7 * * * * ?")); // run every 7 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetContentProcessingWsInitializerJob),
            cronExpression: "0/8 * * * * ?")); // run every 8 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetIntegrationWsInitializerJob),
            cronExpression: "0/9 * * * * ?")); // run every 9 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetReceptionWsInitializerJob),
            cronExpression: "0/10 * * * * ?")); // run every 10 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetResolutionWsInitializerJob),
            cronExpression: "0/11 * * * * ?")); // run every 11 seconds

        services.AddSingleton(new JobSchedule(
            jobType: typeof(NetSchemaValidationWsInitializerJob),
            cronExpression: "0/11 * * * * ?")); // run every 11 seconds
    }

    /// <summary>
    /// Configure application builder
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsStaging() || env.IsProduction())
        {
            app.UseListStartupServicesInstaller();
            app.UseDeveloperExceptionPage();

            app.UseSwaggerInstaller();
        }
        else
        {
            app.UseHsts();
        }

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .AddEnvironmentVariables()
            .Build();

        app.UseRouting();
        app.UseAspBasicInstaller();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
        });

        //#region Proxies
        var serviceProvider = app.ApplicationServices;

        var serviceWsProxy = (IWsConfiguration)serviceProvider.GetService(typeof(IWsConfiguration));
        serviceWsProxy?.EstablishConnection();

        app.UseRoutingVersioningInstaller();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }

} // Class : Startup