using System;
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;

namespace MrFujiBot
{
    public class TwitchBot
    {
        public class StatusArgs : EventArgs
        {
            public enum TwitchBotStatus { Connected,
                                          Disconnected,
                                          ConnectionError,
                                          IncorrectLogin };
            public TwitchBotStatus Status { get; set; }
        }

        public TwitchClient client;
        public event StatusHandler StatusEvent;
        public delegate void StatusHandler(TwitchBot b, TwitchBot.StatusArgs e);

        public TwitchBot(string username, string token, string channel)
        {
            ConnectionCredentials credentials = new ConnectionCredentials(username, token);

            client = new TwitchClient(credentials, channel);
            client.OnConnected += OnConnected;
            client.OnDisconnected += OnDisconnected;
            client.OnConnectionError += OnConnectionError;
            client.OnIncorrectLogin += OnIncorrectLogin;
            client.Connect();
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        private void OnConnected(object sender, OnConnectedArgs e)
        {
            StatusArgs status = new StatusArgs();
            status.Status = StatusArgs.TwitchBotStatus.Connected;
            StatusEvent(this, status);
        }

        private void OnDisconnected(object sender, OnDisconnectedArgs e)
        {
            StatusArgs status = new StatusArgs();
            status.Status = StatusArgs.TwitchBotStatus.Disconnected;
            StatusEvent(this, status);
        }

        private void OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            StatusArgs status = new StatusArgs();
            status.Status = StatusArgs.TwitchBotStatus.ConnectionError;
            StatusEvent(this, status);
        }

        private void OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            StatusArgs status = new StatusArgs();
            status.Status = StatusArgs.TwitchBotStatus.IncorrectLogin;
            StatusEvent(this, status);
        }
    }
}
