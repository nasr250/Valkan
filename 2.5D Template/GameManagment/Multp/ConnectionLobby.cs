﻿using System.Collections.Generic;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class ConnectionLobby : Connection
{
    public List<PlayerList> playerlists = new List<PlayerList>();

    public ConnectionLobby(int port)
        : base(port)
    {
        ar_ = client.BeginReceive(Receive, new object());
        Console.WriteLine("Created lobby connection");
    }

    private void Receive(IAsyncResult ar)
    {
        try
        {
            byte[] bytes = client.EndReceive(ar, ref ip); //store received data in byte array

            if (ip.Address.ToString() != MyIP().ToString()) //check if we did not receive from local ip (we dont need our own data) 
            {
                string message = Encoding.ASCII.GetString(bytes); //convert byte array to string
                Console.WriteLine("\nReceived from {1}:" + port + " ->\n{0}", message, ip.Address.ToString());
                HandleReceivedData(message, ip.Address);
            }
            ar_ = client.BeginReceive(Receive, new object()); ; //repeat
        }
        catch
        {

        }
    }

    public void HandleReceivedData(string message, IPAddress sender) //inspect received data and take action
    {
        string[] lines = message.Split('\n');
        if (lines[0] == "Playerlist:")
        {
            if (playerlists.Count == 0)
            {
                playerlists.Add(new PlayerList());
                playerlists[playerlists.Count - 1].Store(message);
            }
            foreach (PlayerList playerlist in playerlists)
            {
                if (playerlist.IsHost(sender))
                {
                    playerlist.Store(message);
                }
                else //this ip does not exist so create new playerlist
                {
                    playerlists.Add(new PlayerList());
                    playerlists[playerlists.Count - 1].Store(message);
                    GameEnvironment.GameStateManager.GetGameState("hostSelectionState");
                    
                }
            }
        }
    }
    private void StorePlayerLists(IPAddress sender)
    {
        foreach (PlayerList playerlist in playerlists)
        {
            if (playerlist.IsHost(sender))
            {

            }
        }
        playerlists.Add(new PlayerList());

    }

    public void Disconnect() //stop receiving and sending data
    {
        client.Close();
        MultiplayerManager.lobby = null;
        Console.WriteLine("Disconnect from Lobby");
    }
}
