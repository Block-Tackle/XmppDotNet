using XmppDotNet.Xml;
using XmppDotNet.Xmpp.Sasl;
using Xunit;
using Shouldly;

namespace XmppDotNet.Tests.Xmpp.Sasl
{
    public class MechanismTest
    {
        [Fact]
        public void ShouldBeOfTypeMechanism()
        {
            XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanism1.xml")).ShouldBeOfType<Mechanism>();
        }

        [Fact]
        public void TestMechanism()
        {
            var mech = XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanism1.xml")).Cast<Mechanism>();

            string princ = mech.GetAttribute("http://jabber.com/protocol/kerberosinfo", "principal");
            Assert.Equal("xmpp/sso.agsoft.com@SSO.AGSOFT.COM", princ);
        }
    }}
