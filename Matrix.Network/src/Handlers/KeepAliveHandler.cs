﻿// Copyright (c)  AG-Software. All Rights Reserved.
// by Alexander Gnauck (alex@ag-software.net)

using System.Threading;
using System.Threading.Tasks;
using DotNetty.Transport.Channels;

namespace Matrix.Network.Handlers
{
    /// <summary>
    /// a Handler to keep the socket conenction alive by sending a space character every 2 minutes over the existing socket
    /// </summary>
    public class KeepAliveHandler : ChannelHandlerAdapter
    {
        private const string Whitespace = " ";

        private Timer keepaliveTimer;
        public int KeepAliveInterval => 120;


        public override void ChannelActive(IChannelHandlerContext context)
        {
            base.ChannelActive(context);

            int interval = KeepAliveInterval * 1000;
            keepaliveTimer = new Timer(async state =>  await context.Channel.WriteAndFlushAsync(Whitespace), null, interval, interval);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);
            keepaliveTimer.Dispose();
            keepaliveTimer = null;
        }
        
        public override Task WriteAsync(IChannelHandlerContext ctx, object msg)
        {
            if (KeepAliveInterval > 0)
                keepaliveTimer?.Change(KeepAliveInterval * 1000, KeepAliveInterval * 1000);

            return ctx.WriteAsync(msg);
        }
    }
}