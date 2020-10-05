using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using NLog;

[assembly: OwinStartup(typeof(CalculatorService.Server.Startup))]

namespace CalculatorService.Server
{
	public partial class Startup


	{
		public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		public void Configuration(IAppBuilder app)
		{
			//ConfigureAuth(app);
			config();
			logger.Info("This is the server");

		}

		public static void config()
		{
			var config = new NLog.Config.LoggingConfiguration();

			// Targets where to log to: File and Console
			var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
			var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

			// Rules for mapping loggers to targets            
			config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
			config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);

			// Apply config           
			NLog.LogManager.Configuration = config;

		}
	}
}
