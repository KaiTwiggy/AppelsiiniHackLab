using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus.Messaging;
using System.Threading.Tasks;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = System.Configuration.ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string eventHubName = System.Configuration.ConfigurationManager.AppSettings["EventHubName"];
            string storageAccountName = System.Configuration.ConfigurationManager.AppSettings["StorageAccountName"];
            string storageAccountKey = System.Configuration.ConfigurationManager.AppSettings["StorageAccountKey"];
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>().Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
        }

    }
}
