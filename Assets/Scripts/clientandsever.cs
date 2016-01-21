using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class clientandsever : MonoBehaviour
{
    public bool isAtStartup = true;
    NetworkClient myClient;

    public void SetupServer()
    {
        NetworkServer.Listen(8888);
        isAtStartup = false;
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("192.16.7.21", 8888);
        isAtStartup = false;
    }

    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}
