using Serilog;
using Serilog.Events;

namespace Flogging.Core
{
	public static class Flogger
	{
		private static readonly ILogger _perfLogger;
		private static readonly ILogger _usageLogger;
		private static readonly ILogger _errorLogger;
		private static readonly ILogger _diagnosticLogger;

		private static string seqIp = "http://172.17.17.230:5341";


		static Flogger()
		{
			_perfLogger = new LoggerConfiguration()
				//.WriteTo.File(path: @"c:\LogFiles\perf.txt")
				.WriteTo.Seq(seqIp)
				.CreateLogger();

			_usageLogger = new LoggerConfiguration()
				//.WriteTo.File(path: @"c:\LogFiles\usage.txt")
				.WriteTo.Seq(seqIp)
				.CreateLogger();

			_errorLogger = new LoggerConfiguration()
				//.WriteTo.File(path: @"c:\LogFiles\error.txt")
				.WriteTo.Seq(seqIp)
				.CreateLogger();

			_diagnosticLogger = new LoggerConfiguration()
				//.WriteTo.File(path: @"c:\LogFiles\diagnostic.txt")
				.WriteTo.Seq(seqIp)
				.CreateLogger();
		}

		public static void WritePerf(FlogDetail infoToLog)
		{
			_perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
		}

		public static void WriteUsage(FlogDetail infoToLog)
		{
			_usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
		}

		public static void WriteError(FlogDetail infoToLog)
		{
			_errorLogger.Write(LogEventLevel.Error, "{@FlogDetail}", infoToLog);
		}

		public static void WriteDiagnostic(FlogDetail infoToLog)
		{
			//var writeDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
            /*
			if (!writeDiagnostics)
			{
				return;
			}
            */

			_diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
		}
	}
}
