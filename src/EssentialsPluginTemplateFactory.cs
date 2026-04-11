using System.Collections.Generic;
using PepperDash.Core;
using PepperDash.Essentials.Core;

namespace EssentialsPluginTemplate
{
	/// <summary>
	/// Plugin device factory for devices that use IBasicCommunication
	/// </summary>
	/// <remarks>
	/// Rename the class to match the device plugin being developed
	/// </remarks>
	/// <example>
	/// "EssentialsPluginFactoryTemplate" renamed to "MyDeviceFactory"
	/// </example>
    public class EssentialsPluginTemplateFactory : EssentialsPluginDeviceFactory<EssentialsDevice>
    {
		/// <summary>
		/// Plugin device factory constructor
		/// </summary>
		/// <remarks>
		/// Update the MinimumEssentialsFrameworkVersion & TypeNames as needed when creating a plugin
		/// </remarks>
		/// <example>
 		/// Set the minimum Essentials Framework Version
		/// <code>
		/// MinimumEssentialsFrameworkVersion = "1.6.4";
        /// </code>
		/// In the constructor we initialize the list with the typenames that will build an instance of this device
        /// <code>
		/// TypeNames = new List<string>() { "SamsungMdc", "SamsungMdcDisplay" };
        /// </code>
		/// </example>
        public EssentialsPluginTemplateFactory()
        {
#if SERIES4
            MinimumEssentialsFrameworkVersion = "2.28.1";
#else
            MinimumEssentialsFrameworkVersion = "1.6.4";
#endif
            TypeNames = new List<string>() { "TcpProxy" };
        }
        
		/// <summary>
		/// Builds and returns an instance of EssentialsPluginDeviceTemplate
		/// </summary>
		/// <param name="dc">device configuration</param>
		/// <returns>plugin device or null</returns>
		/// <remarks>		
		/// The example provided below takes the device key, name, properties config and the comms device created.
		/// Modify the EssetnialsPlugingDeviceTemplate constructor as needed to meet the requirements of the plugin device.
		/// </remarks>
		/// <seealso cref="PepperDash.Core.eControlMethod"/>
        public override EssentialsDevice BuildDevice(PepperDash.Essentials.Core.Config.DeviceConfig dc)
        {
#if SERIES4
            Debug.LogVerbose("[{key}] Factory Attempting to create new device from type: {type}", dc.Key, dc.Type);
#else
            Debug.Console(1, "[{0}] Factory Attempting to create new device from type: {1}", dc.Key, dc.Type);
#endif

            var propertiesConfig = dc.Properties.ToObject<TcpProxyConfigObject>();
            if (propertiesConfig == null)
            {
#if SERIES4
                Debug.LogError("[{key}] Factory: failed to read properties config for {name}", dc.Key, dc.Name);
#else
                Debug.Console(0, "[{0}] Factory: failed to read properties config for {1}", dc.Key, dc.Name);
#endif
                return null;
            }
            var comms = CommFactory.CreateCommForDevice(dc);
            if (comms == null)
            {
#if SERIES4
                Debug.LogError("[{key}] Factory Notice: No control object present for device {name}", dc.Key, dc.Name);
#else
                Debug.Console(1, "[{0}] Factory Notice: No control object present for device {1}", dc.Key, dc.Name);
#endif
                return null;
            }
            else
            {
                return new ForwardingDevice(dc.Key, dc.Name, propertiesConfig);
            }

        }

    }



}

          