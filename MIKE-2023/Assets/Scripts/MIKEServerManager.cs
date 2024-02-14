using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class MIKEServerManager : MonoBehaviour
{

    private Queue<byte[]> dataToReceive = new Queue<byte[]>();
    private bool tasksRunning = true;

    // Start TCP server
    void Awake()
    {

        Task.Run(async () =>
        {
            using (var udpClient = new UdpClient(7777))
            {
                while (tasksRunning)
                {
                    //IPEndPoint object will allow us to read datagrams sent from any source.
                    var receivedResults = await udpClient.ReceiveAsync();
                    dataToReceive.Enqueue(receivedResults.Buffer);
                    Debug.Log(receivedResults.Buffer.Length);
                }
            }
        }); 

    }

    void OnDisable()
    {
        tasksRunning = false;
        Debug.Log("Server stopped.");
    }

    void Update()
    {

        if(dataToReceive.Count > 0)
        {
            MIKEInputManager.Main.ReceiveInput(dataToReceive.Dequeue());
        }

    }

}