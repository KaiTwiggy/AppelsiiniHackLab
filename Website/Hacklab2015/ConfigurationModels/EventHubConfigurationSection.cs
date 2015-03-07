using System.Configuration;

namespace Hacklab2015.ConfigurationModels
{
	public class EventHubConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty("hubconfig"),
		ConfigurationCollection(typeof(HackLabConfigurationElementCollection<string, RelayModelSection>), AddItemName = "item")
		]
		public HackLabConfigurationElementCollection<string, RelayModelSection> ConfigItems
		{
			get { return this["hubconfig"] as HackLabConfigurationElementCollection<string, RelayModelSection>; }
			set { this["hubconfig"] = value; }
		}
	}
}