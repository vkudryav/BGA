using Google.Apis.Analytics.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellicose.GoogleAnalytics.Interfaces
{
    public interface IQueryer
    {
        /// <summary>
        /// Execute a query and return a GaData object with the results
        /// </summary>
        /// <param name="viewId">Required: "ga:" + the View ID found in https://www.google.com/ahalytics/web in the admin section under the specific view/profile desired</param>
        /// <param name="startDate">Required: Start Date of query in format "yyyy-mm-dd"</param>
        /// <param name="endDate">Required: End  Date of query in format "yyyy-mm-dd"</param>
        /// <param name="metrics">Required: One or more GA metrics in comma-separated list in format "ga:totalEvents".  Official list is here https://developers.google.com/analytics/devguides/reporting/core/dimsmets. </param>
        /// <param name="dimensions">Optional: One or more GA dimensions in comma-separated list in format "ga:date" Official list is here https://developers.google.com/analytics/devguides/reporting/core/dimsmets .</param>
        /// <param name="filters">Optional: Data filter for the defined view.</param>
        /// <param name="sort">Optional: Sort specification for the defined view.</param>
        /// <param name="startIndex">Optional: Start index of item to return from the query (when returning a page of data, for example)</param>
        /// <param name="maxResults">Optional: Maximum items to return from the query</param>
        /// <returns></returns>
        GaData ExecuteQuery(string viewId, string startDate, string endDate, string metrics,
            string dimensions = null,
            string filters = null,
            string sort = null);
    }
}
