using System.Collections.Generic;
using Newtonsoft.Json;
using PepperDash.Essentials.Core;

namespace EssentialsPluginTemplate
{
	/// <summary>
	/// Plugin device configuration object
	/// </summary>
	/// <remarks>
	/// Rename the class to match the device plugin being created
	/// </remarks>
	/// <example>
	/// "EssentialsPluginConfigObjectTemplate" renamed to "SamsungMdcConfig"
	/// </example>
	[ConfigSnippet("\"properties\":{\"control\":{}")]
	public class TcpProxyConfigObject
	{
		
		[JsonProperty("clientAddress")]
		public string ClientAddress { get; set; }

        [JsonProperty("clientPort")]
        public int ClientPort { get; set; }

        [JsonProperty("serverPort")]
        public int serverPort { get; set; }

		[JsonProperty("DeviceDictionary")]
		public Dictionary<string, EssentialsPluginTemplateConfigObjectDictionary> DeviceDictionary { get; set; }

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <remarks>
		/// If using a collection you must instantiate the collection in the constructor
		/// to avoid exceptions when reading the configuration file 
		/// </remarks>
        public TcpProxyConfigObject()
		{
			DeviceDictionary = new Dictionary<string, EssentialsPluginTemplateConfigObjectDictionary>();
		}
	}

	/// <summary>
	/// Example plugin configuration dictionary object
	/// </summary>
	/// <remarks>
	/// This is an example collection of configuration objects.  This can be modified or deleted as needed for the plugin being built.
	/// </remarks>
	/// <example>
	/// <code>
	/// "properties": {
	///		"dictionary": {
	///			"item1": {
	///				"name": "Item 1 Name",
	///				"value": "Item 1 Value"
	///			}
	///		}
	/// }
	/// </code>
	/// </example>
	public class EssentialsPluginTemplateConfigObjectDictionary
	{
		/// <summary>
		/// Serializes collection name property
		/// </summary>
		/// <remarks>
		/// This is an example collection of configuration objects.  This can be modified or deleted as needed for the plugin being built.
		/// </remarks>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Serializes collection value property
		/// </summary>
		/// <remarks>
		/// This is an example collection of configuration objects.  This can be modified or deleted as needed for the plugin being built.
		/// </remarks>
		[JsonProperty("value")]
		public uint Value { get; set; }
	}
}