
using System.Configuration;

namespace Hacklab2015.ConfigurationModels
{
	public class RelayModelSection : HackLabConfigurationElement<string>
	{
		[ConfigurationProperty("key")]
		public string Key
		{
			get { return (string)this["key"]; }
			set { this["key"] = value; }
		}

		[ConfigurationProperty("value")]
		public string Value
		{
			get { return (string)this["value"]; }
			set { this["value"] = value; }
		}

		public override string GetKey()
		{
			return Key;
		}
	}
}