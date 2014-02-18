using Bellicose.GoogleAnalytics.Interfaces;
using DotNetOpenAuth.Messaging;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Bellicose.GoogleAnalytics.Concrete
{
	public class Queryer : IQueryer
	{
		#region Fields, Attributes, Constants
		private readonly AnalyticsService _service;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a Queryer object to perform queries on Google Analytics, using a Service Account
		/// </summary>
		/// <param name="keyFilePath">Path to the Service Account's key file (what you download when you create a service account)</param>
		/// <param name="keyPassword">The password for the key file (defaults to "notapassword" when you create the service account)</param>
		/// <param name="serviceAccountEmail">The email associated with the service account (in format "(number)@developer.gserviceaccount.com")</param>
		/// <param name="applicationName">Name of application (I used the Name field in the Project Summary panel in https://code.google.com/apis/console/ )</param>
		public Queryer(string keyFilePath, string keyPassword, string serviceAccountEmail, string applicationName)
		{
			var key = new X509Certificate2(keyFilePath, keyPassword, X509KeyStorageFlags.Exportable);
			var credential = new ServiceAccountCredential(
								new ServiceAccountCredential.Initializer(serviceAccountEmail)
								{
									Scopes = new[] { AnalyticsService.Scope.Analytics }
								}.FromCertificate(key));

			// Create the service.
			_service =
				new AnalyticsService(new BaseClientService.Initializer()
				{
					ApplicationName = applicationName,
					HttpClientInitializer = credential
				});
		}
		#endregion

		#region ExecuteQuery
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
		public GaData ExecuteQuery(string viewId, string startDate, string endDate, string metrics,
			 string dimensions = null,
			 string filters = null,
			 string sort = null)
		{
			int startIndex = 1;
			int maxResults = 10000;
			GaData result = null;
			GaData finalResult = null;

			do
			{
				var request = GetRequest(viewId, startDate, endDate, metrics, dimensions, startIndex, maxResults,
					 filters, sort);
				result = request.Execute();

				//Either create the final result from the first 5K rows or append the 5K rows onto the final result
				if (finalResult == null)
				{
					finalResult = result;
				}
				else if (result.Rows != null && result.Rows.Count > 0)
				{
					finalResult.Rows.AddRange(result.Rows);
				}
				startIndex = startIndex + maxResults;
			} while (result.Rows != null && result.Rows.Count > 0);

			return finalResult;
		}

		private DataResource.GaResource.GetRequest GetRequest(string viewId, string startDate, string endDate, string metrics, string dimensions,
			 int startIndex, int maxResults,
			 string filters = null,
			 string sort = null)
		{
			if (viewId == null)
				throw new Exception("GAViewID is required to execute a query");
			if (startDate == null)
				throw new Exception("StartDate is required to execute a query");
			if (endDate == null)
				throw new Exception("EndDate is required to execute a query");
			if (metrics == null)
				throw new Exception("Metrics is required to execute a query");

			DataResource.GaResource.GetRequest request = null;
			try
			{
				request = _service.Data.Ga.Get(viewId, startDate, endDate, metrics);
				request.StartIndex = startIndex;
				request.MaxResults = maxResults;

				if (dimensions != null)
					request.Dimensions = dimensions;
				if (filters != null)
					request.Filters = filters;
				if (sort != null)
					request.Sort = sort;
			}
			catch (Exception ex)
			{

			}

			return request;
		}
		#endregion
	}
}
