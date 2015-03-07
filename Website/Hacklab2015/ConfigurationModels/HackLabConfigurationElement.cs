using System.Configuration;

namespace Hacklab2015.ConfigurationModels
{
	public abstract class HackLabConfigurationElement<TKey> : ConfigurationElement
	{
		public abstract TKey GetKey();
	}

}