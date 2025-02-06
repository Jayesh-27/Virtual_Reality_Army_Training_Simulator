using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class UDPReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private int port = 12345; // Change this to the same port as in the ESP8266 code
    private string expectedIPAddress = "192.168.1.3"; // Change this to the specific IP address of your ESP8266

    void Start()
    {
        udpClient = new UdpClient(port);
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        byte[] data = udpClient.Receive(ref remoteEndPoint);

        if (data.Length > 0 && remoteEndPoint.Address.ToString() == expectedIPAddress)
        {
            int buttonState = BitConverter.ToInt32(data, 0);

            // Use buttonState as needed in your Unity application
            Debug.Log("Button State from " + expectedIPAddress + ": " + buttonState);
        }
    }

    void OnDisable()
    {
        if (udpClient != null)
        {
            udpClient.Close();
        }
    }
}
