using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bellicose.GoogleAnalytics.Concrete;
using Bellicose.GoogleAnalytics.Interfaces;
using Google.Apis.Analytics.v3.Data;
using System.Configuration;

namespace Bellicose.GoogleAnalytics.GoogleAnalyticsQueryer
{
    class Program
    {
        static private Options _options;

        static void Main(string[] args)
        {
            Console.WriteLine(args[11]);
            try
            {
                var success = RetrieveArgs(args);
                if (success)
                {
                    IQueryer queryer = GetQueryer();
                    GaData result = PerformQuery(queryer);
                    Console.WriteLine(_options.OutputFilePath);
                    Console.WriteLine(result);
                    Serialize(result, _options.OutputFilePath);

                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                // Display exception to stdout similarly to normal operatoin
                using (var s = new StreamWriter(Console.OpenStandardError()))
                {
                    WriteExceptionRecursive(e, s);
                }
                //return a non-zero exit code to make SSIS error
                Environment.ExitCode = 1;
            }
        }

        private static void WriteExceptionRecursive(Exception e, StreamWriter s)
        {
            s.WriteLine("Exception Encountered:");
            s.WriteLine("Message: " + e.Message);
            s.WriteLine("Stack Trace: " + e.StackTrace);
            if (e.InnerException != null)
            {
                WriteExceptionRecursive(e.InnerException, s);
            }
        }

        private static bool RetrieveArgs(string[] args)
        {
            _options = new Options();
            string[] x = args.Select(a => a.Trim(',')).ToArray();
            return (CommandLine.Parser.Default.ParseArguments(args.Select(a => a.Trim(',')).ToArray(), _options));
        }

        private static IQueryer GetQueryer()
        {
            string keyFilePath = ConfigurationManager.AppSettings["keyFilePath"];
            string keyFilePassword = ConfigurationManager.AppSettings["keyFilePassword"];
            string serviceAccountEmail = ConfigurationManager.AppSettings["serviceAccountEmail"];
            string applicationName = ConfigurationManager.AppSettings["applicationName"];
            return new Queryer(keyFilePath, keyFilePassword, serviceAccountEmail, applicationName);
        }

        private static GaData PerformQuery(IQueryer queryer)
        {
            return queryer.ExecuteQuery(_options.ViewId, _options.StartDate, _options.EndDate, _options.Metrics,_options.Dimensions, filters :_options.Filters);
        }

        private static void Serialize(GaData result, string filePath)
        {
            IGaDataSerializer serializer = new GaDataTsvRecursiveSerializer(filePath);
            serializer.Serialize(result);
        }
    }
}
