using DilmerGames.Core.Singletons;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class DroneClient : Singleton<DroneClient>
{
    // Drone Client sets up the UDP connection with the drone, and provides some useful (and important) variables, such as whether or not the SDK is initialized and so on
    private static readonly object lockObject = new object();

    [SerializeField]
    private string droneIP = "192.168.10.1";

    [SerializeField]
    private int controllerPort = 8889;

    [SerializeField]
    private int statePort = 8890;

    [SerializeField, Tooltip("Used for Standalone Scene")]
    private bool connectInAwake = false;

    private UdpClient UdpClient { set; get; }

    private Thread receivingThread;

    public bool Connected { private set; get; }

    // SDKInitialized: is required before sending flying commands the drone
    // this is pretty much saying let's add SDK connectivity
    public bool SDKInitialized { private set; get; }

    [SerializeField]
    private DroneStats droneStats = new DroneStats();

    public DroneStats DroneStats => droneStats;

    // logging

    // Use messages to queued up log entries
    // normally needed when using a secondary thread
    public Queue<string> LogMessages { get; set; } = new Queue<string>();
    // All update does is continouusly log, which is a little different from how things are normally done in Unity, but other comoponents in this file are run on another thread
    void Update()
    {
        if (LogMessages.Count > 0)
        {
            string message = LogMessages.Dequeue();
            Logger.Instance.LogInfo(message);
        }
    }

    public void Awake()
    {
        if (!connectInAwake) return;
        StartDrone();
    }

    public void StartDrone()
    {
        if (Connected) return;

        UdpClient = new UdpClient();
        UdpClient.Client.Bind(new IPEndPoint(IPAddress.Any, statePort));

        // start threads
        CreateThread(receivingThread, StateReceiver);

        Connected = true;
    }

    private void CreateThread(Thread thread, Action action)
    {
        thread = new Thread(new ThreadStart(action));
        thread.Start();
    }

    // This method should only be used for control type commands
    // use DroneRequest parameter to read and control commands
    
    // This method is used to send commands to th drone, over UDP to the specific IP endpoint that handles commands, as defined in variables above
    public void SendCommand(string command)
    {
        Enum.TryParse(command, out DroneCommand droneCommand);

        var droneRequest = new DroneRequest
        {
            RequestType = RequestType.ControlCommand,
            Command = droneCommand
        };

        LogMessages.Enqueue($"{droneRequest.Command} {droneRequest.RequestType} {droneRequest.Payload}");

        byte[] message = Encoding.ASCII.GetBytes($"{droneRequest.Payload}");
        UdpClient.Send(message, message.Length, new IPEndPoint(IPAddress.Parse(droneIP), controllerPort));
    }

    public void SendCommand(DroneRequest droneRequest)
    {
        LogMessages.Enqueue($"{droneRequest.Command} {droneRequest.RequestType} {droneRequest.Payload}");

        byte[] message = Encoding.ASCII.GetBytes($"{droneRequest.Payload}");
        UdpClient.Send(message, message.Length, new IPEndPoint(IPAddress.Parse(droneIP), controllerPort));
    }
    // Run on its own thread, to constantly receive the state from the drone and update the stats in UI
    public void StateReceiver()
    {
        while (true)
        {
            lock (lockObject)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, statePort);
                try
                {
                    byte[] receiveBytes = UdpClient.Receive(ref RemoteIpEndPoint);
                    string response = Encoding.ASCII.GetString(receiveBytes);

                    if (response == $"{ResponseType.ok}")
                    {
                        SDKInitialized = true;
                        UpdateLogWithLock(response);
                    }
                    else if (response == $"{ResponseType.error}")
                    {
                        UpdateLogWithLock(response);
                    }
                    else if (response.Contains(";"))
                    {
                        droneStats.UpdateStats(response);
                    }
                }
                catch (Exception e)
                {
                    UpdateLogWithLock(e.Message);
                }
            }
        }
    }

    private void UpdateLogWithLock(string message)
    {
        lock (lockObject)
        {
            LogMessages.Enqueue(message);
        }
    }

    private void OnDestroy()
    {
        if (UdpClient != null)
        {
            UdpClient.Close();
            UdpClient.Dispose();
        }

        if (receivingThread != null) receivingThread.Abort();
    }
}
