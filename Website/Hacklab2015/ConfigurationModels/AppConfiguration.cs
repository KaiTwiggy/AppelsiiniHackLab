using System.Configuration;

namespace Hacklab2015.ConfigurationModels
{
	public class AppConfiguration
	{
		public static EventHubConfigurationSection EventHubConfigs
		{
			get
			{
				return GetSection<EventHubConfigurationSection>("hackLab/eventHub");
			}
		}
		private static T GetSection<T>(string name) where T : ConfigurationSection
		{
			var config = ConfigurationManager.GetSection(name) as T;
			if (config == null)
			{
				throw new ConfigurationErrorsException(string.Format("Section {0} is missing from web.config.", name));
			}
			return config;
		}
	}
}