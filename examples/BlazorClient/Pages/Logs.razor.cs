﻿namespace BlazorClient.Pages
{
    using XmppDotNet;
    using XmppDotNet.Extensions.Client.Presence;
    using XmppDotNet.Extensions.Client.Roster;
    using XmppDotNet.Transport.WebSocket;
    using XmppDotNet.Xmpp;

    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ViewModels;

    public partial class Logs
    {
        private Account Account { get; } = new();
        private ObservableCollection<LogMessage> LogMessages { get; } = new();

        readonly XmppClient xmppClient;

        public Logs()
        {
            xmppClient = new XmppClient(
                conf =>
                {
                    conf.UseWebSocketTransport();
                    conf.AutoReconnect = true;
                }
            );
            
            xmppClient
                .Transport
                .XmlReceived
                .Subscribe(el =>
                {
                    InvokeAsync(()=>
                    {
                        LogMessages.Add(new LogMessage() {Direction = "RECV", Xml = el.ToString()});
                        StateHasChanged();
                    });
                    
                });

            xmppClient
                .Transport
                .XmlSent
                .Subscribe(el =>
                {
                    InvokeAsync(() =>
                    {
                        LogMessages.Add(new LogMessage() {Direction = "SEND", Xml = el.ToString()});
                        StateHasChanged();
                    });
                });

        }

        private async Task Connect()
        {
            xmppClient.Jid = Account.Jid;
            xmppClient.Password = Account.Password;

            await xmppClient.ConnectAsync();
            await xmppClient.RequestRosterAsync();
            await xmppClient.SendPresenceAsync(Show.Chat, "free for chat");
        }

        private async Task Disconnect()
        {
            await xmppClient.DisconnectAsync();
        }
    }
}