
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using System;
using System.IO;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IConsumer, Consumer>();
               })
               .UseSerilog()
               .Build();

            var app = ActivatorUtilities.CreateInstance<Application>(host.Services);
            await app.Start(args);

            Console.ReadLine();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Local"}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
