using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TransportNET : MonoBehaviour {

    byte error;
    byte[] buffer = new byte[1024];

    void Start ()
    {
        NetworkTransport.Init();

        ConnectionConfig config = new ConnectionConfig();

        int myReiliableChannelId = config.AddChannel(QosType.Reliable);
        int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
        HostTopology topology = new HostTopology(config, 10);

        int hostId = NetworkTransport.AddHost(topology, 8888);

        int bufferLength = buffer.Length;
        int connectionId = NetworkTransport.Connect(hostId, "192.16.7.21", 8888, 0, out error);
        NetworkTransport.Disconnect(hostId, connectionId, out error);
        NetworkTransport.Send(hostId, connectionId, myReiliableChannelId, buffer, bufferLength, out error);
    }
}
