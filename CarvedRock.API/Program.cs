using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CarvedRock.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var name = typeof(Program).Assembly.GetName().Name;

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.Enrich.WithMachineName()
				.Enrich.WithProperty("Assembly", name) 
				.WriteTo.Console()
				.WriteTo.Seq(serverUrl: "http://host.docker.internal:5341")
				//.WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			Log.Information("Hello, world!");

			try
			{
				Log.Information("starting");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Something went wrong");
			}
			finally
			{
				Log.CloseAndFlush();
			}


		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.UseSerilog()
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
