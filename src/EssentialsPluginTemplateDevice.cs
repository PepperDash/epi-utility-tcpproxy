// For Basic SIMPL# Classes
// For Basic SIMPL#Pro classes

using Crestron.SimplSharpPro.DeviceSupport;
using PepperDash.Core;
using PepperDash.Essentials.Core;
using PepperDash.Essentials.Core.Bridges;
using PepperDash.Essentials.Core.Queues;
using Crestron.SimplSharp.CrestronSockets;
using PepperDash.Essentials.Core.Config;
using System.Collections.Generic;


namespace EssentialsPluginTemplate
{
	/// <summary>
	/// Plugin device template for third party devices that use IBasicCommunication
	/// </summary>
	/// <remarks>
	/// Rename the class to match the device plugin being developed.
	/// </remarks>
	/// <example>
	/// "EssentialsPluginDeviceTemplate" renamed to "SamsungMdcDevice"
	/// </example>
	public class ForwardingDevice : EssentialsDevice
    {
            private GenericTcpIpServer server;   
            private GenericTcpIpClient client;
            private TcpProxyConfigObject _Config;

            public ForwardingDevice(string key, string name, TcpProxyConfigObject config)
                : base(key, name)
            {
                _Config = config;

                client = new GenericTcpIpClient(string.Format("{0}-client", this.Key));
                client.ConnectionChange += new System.EventHandler<GenericSocketStatusChageEventArgs>(client_ConnectionChange);
                // Start the server
                server = new GenericTcpIpServer(string.Format("{0}-server", this.Name));
                server.Port = _Config.serverPort;
                server.ClientConnectionChange += new System.EventHandler<GenericTcpServerSocketStatusChangeEventArgs>(server_ClientConnectionChange);
                server.TextReceived += new System.EventHandler<GenericTcpServerCommMethodReceiveTextArgs>(server_TextReceived);
                server.Listen();
                server.MaxClients = 1;
            }

            void server_ClientConnectionChange(object sender, GenericTcpServerSocketStatusChangeEventArgs e)
            {
                if (e.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    client.Connect();
                }
                else if (e.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED || e.ClientStatus != SocketStatus.SOCKET_STATUS_WAITING)
                {
                    if (client.Connected)
                    {
                        client.Disconnect();
                    }
                }
            }

            void client_ConnectionChange(object sender, GenericSocketStatusChageEventArgs e)
            {
                    Debug.Console(0, this, "Error connecting client: {0}", e.Client.ClientStatus);
            }

            void server_TextReceived(object sender, GenericTcpServerCommMethodReceiveTextArgs e)
            {
                // Forward data to client
                if (client != null && client.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    client.SendText(e.Text);
                }

                // Log data
                Debug.Console(0, this, "Received data from server: {0}", e.Text);
            }


        }



    }

