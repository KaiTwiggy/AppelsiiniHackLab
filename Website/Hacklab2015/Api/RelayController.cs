using Hacklab2015.ConfigurationModels;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Linq;
using System.Web.Http;


namespace Hacklab2015.Api
{
	public class RelayApiController : ApiController
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		[HttpGet]
		[HttpPost]
		public async void RelayMessage()
		{
			string eventHubName = AppConfiguration.EventHubConfigs.ConfigItems.FirstOrDefault(x => x.Key == "hubName").Value;

			string connectionString =
			AppConfiguration.EventHubConfigs.ConfigItems.FirstOrDefault(x => x.Key == "connectionString").Value;
			var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);

			var content =  Request.Content.ReadAsStringAsync();
			await content;
			var testing = AppConfiguration.EventHubConfigs.ConfigItems;
			try
			{
				log.InfoFormat("{0} > Sending message: {1}", DateTime.Now.ToString(), content.Result);

				using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(content.Result)))
				{
					//eventHubClient.Send(new EventData(stream));	
				}		
			}
			catch (Exception exception)
			{
				log.ErrorFormat("{0} > Exception: {1}", DateTime.Now.ToString(), exception.Message);
			}
		}

	}
}
