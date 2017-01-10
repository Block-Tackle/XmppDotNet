﻿using System.Text;
using Matrix.Xml;
using Xunit;


namespace Matrix.Xmpp.Tests.Sasl
{
    [Collection("Factory collection")]
    public class AuthTest
    {
        const string XML1 = "<auth xmlns='urn:ietf:params:xml:ns:xmpp-sasl'>ZHVtbXkgdmFsdWU=</auth>";

        [Fact]
        public void Test1()
        {
            XmppXElement xmpp1 = XmppXElement.LoadXml(XML1);


            var resp = xmpp1 as Matrix.Xmpp.Sasl.Auth;

            byte[] bval = resp.Bytes;
            string sval = Encoding.ASCII.GetString(bval);
            Assert.Equal("dummy value", sval);

            var auth2 = new Matrix.Xmpp.Sasl.Auth { Bytes = Encoding.ASCII.GetBytes("dummy value") };
            auth2.ShouldBe(XML1);
            
            var auth3 = new Matrix.Xmpp.Sasl.Auth { Bytes = null };
        }
    }
}