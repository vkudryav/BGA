using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellicose.GoogleAnalytics.GoogleAnalyticsQueryer
{
    // Define a class to receive parsed values
    class Options
    {
        [Option('v', "viewid", Required = true,
          HelpText = "GoogleAnalytics ViewID in form of \"ga:99999999\"")]
        public string ViewId { get; set; }

        [Option('s', "startdate", Required = true,
          HelpText = "Query Start Date in form of yyyy-mm-dd")]
        public string StartDate { get; set; }

        [Option('e', "enddate", Required = true,
          HelpText = "Query Start Date in form of yyyy-mm-dd")]
        public string EndDate { get; set; }

        [Option('m', "metrics", Required = true,
          HelpText = "Comma-separated list of 1-10 metrics.  Official list https://developers.google.com/analytics/devguides/reporting/core/dimsmets")]
        public string Metrics { get; set; }

        [Option('d', "dimensions", Required = false,
          HelpText = "Comma-separated list of 1-7 dimensions.  Official list https://developers.google.com/analytics/devguides/reporting/core/dimsmets")]
        public string Dimensions { get; set; }

        [Option('f', "filter", Required = false,
          HelpText = "GoogleAnalytics filter specification")]
        public string Filters { get; set; }

        [Option('o', "sort", Required = false,
          HelpText = "GoogleAnalytics sort specification")]
        public string Sort { get; set; }

        [Option('i', "startindex", Required = false,
          HelpText = "Index of first row in result to return")]
        public string StartIndex { get; set; }

        [Option('x', "maxrows", Required = false,
          HelpText = "Maximum number of rows to return")]
        public string MaxResults { get; set; }

        [Option('p', "outputpath", Required = true,
          HelpText = "Path of output file to receive result")]
        public string OutputFilePath { get; set; }

        
        [Option('b', "verbose", DefaultValue = true,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
