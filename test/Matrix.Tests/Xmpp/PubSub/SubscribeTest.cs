/*
 * Copyright (c) 2003-2020 by AG-Software <info@ag-software.de>
 *
 * All Rights Reserved.
 * See the COPYING file for more information.
 *
 * This file is part of the MatriX project.
 *
 * NOTICE: All information contained herein is, and remains the property
 * of AG-Software and its suppliers, if any.
 * The intellectual and technical concepts contained herein are proprietary
 * to AG-Software and its suppliers and may be covered by German and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 *
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from AG-Software.
 *
 * Contact information for AG-Software is available at http://www.ag-software.de
 */

using Matrix.Xml;
using Matrix.Xmpp.PubSub;
using Shouldly;
using Xunit;

namespace Matrix.Tests.Xmpp.PubSub
{
    public class SubscribeTest
    {
        [Fact]
        public void ShoudBeOfTypeSubscribe()
        {
            XmppXElement.LoadXml(Resource.Get("Xmpp.PubSub.subscribe1.xml")).ShouldBeOfType<Subscribe>();
        }

        [Fact]
        public void TestSubscribe()
        {
            var sub = XmppXElement.LoadXml(Resource.Get("Xmpp.PubSub.subscribe1.xml")).Cast<Subscribe>();
            Assert.Equal(sub.Node, "princely_musings");
            Assert.Equal(sub.Jid.ToString(), "francisco@denmark.lit");
        }

        [Fact]
        public void TestBuildSubscribe()
        {
            var sub = new Subscribe { Node = "princely_musings", Jid = "francisco@denmark.lit" };
            sub.ShouldBe(Resource.Get("Xmpp.PubSub.subscribe1.xml"));
        }
    }
}
