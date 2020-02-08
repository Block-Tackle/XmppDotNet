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
using Matrix.Xmpp.PubSub.Owner;
using Shouldly;
using Xunit;

namespace Matrix.Tests.Xmpp.PubSub.Owner
{
    public class PurgeTest
    {
        [Fact]
        public void ShoudBeOfTypeCollection()
        {
            XmppXElement.LoadXml(Resource.Get("Xmpp.PubSub.Owner.purge1.xml")).ShouldBeOfType<Purge>();
        }

        [Fact]
        public void TestPurge()
        {
            var purge = XmppXElement.LoadXml(Resource.Get("Xmpp.PubSub.Owner.purge1.xml")).Cast<Purge>();
            Assert.Equal(purge.Node, "princely_musings");
        }

        [Fact]
        public void BuildPurge()
        {
            new Purge { Node = "princely_musings" }.ShouldBe(Resource.Get("Xmpp.PubSub.Owner.purge1.xml"));
        }
    }
}
