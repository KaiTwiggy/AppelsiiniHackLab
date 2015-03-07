using Microsoft.ServiceBus.Messaging;
using System;
using System.Web.Http;


namespace Hacklab2015.Api
{
	public class RelayApiController : ApiController
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		private static string eventHubName = "apphackhub";
		private static string connectionString = "Endpoint=sb://apphackhub.servicebus.windows.net/;SharedAccessKeyName=SendRule;SharedAccessKey=d04W2rCsiKQtRHUlZbX9gcdYP6q7ZcIo4YsBtk2q31E=";

		[HttpGet]
		[HttpPost]
		public async void RelayMessage()
		{
			var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

			var content =  Request.Content.ReadAsStringAsync();
			await content;

			try
			{
				log.InfoFormat("{0} > Sending message: {1}", DateTime.Now.ToString(), content.Result);

				using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(content.Result)))
				{
					eventHubClient.Send(new EventData(stream));	
				}		
			}
			catch (Exception exception)
			{
				log.ErrorFormat("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
			}
		}

	}
}
