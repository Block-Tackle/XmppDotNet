using XmppDotNet.Xml;
using XmppDotNet.Xmpp.Sasl;
using Xunit;
using Shouldly;

namespace XmppDotNet.Tests.Xmpp.Sasl
{
    public class MechanismsTest
    {
        [Fact]
        public void ShouldBeOfTypeMechanisms()
        {
            XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms1.xml")).ShouldBeOfType<Mechanisms>();
            XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms2.xml")).ShouldBeOfType<Mechanisms>();
            XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms3.xml")).ShouldBeOfType<Mechanisms>();
        }

        [Fact]
        public void TestMechanisms1()
        {
            var mechs = XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms1.xml")).Cast<Mechanisms>();
            Assert.True(mechs.SupportsMechanism(SaslMechanism.DigestMd5));
            Assert.True(mechs.SupportsMechanism(SaslMechanism.Plain));
            Assert.True(mechs.SupportsMechanism(SaslMechanism.Gssapi));
            Assert.False(mechs.SupportsMechanism(SaslMechanism.Anonymous));
            Assert.False(mechs.SupportsMechanism(SaslMechanism.XGoogleToken));
        }

        [Fact]
        public void TestMechanisms2()
        {
            var mechanisms = XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms2.xml")).ShouldBeOfType<Mechanisms>();
            Assert.Equal("auth42.us.example.com", mechanisms.PrincipalHostname);
        }

        [Fact]
        public void TestMechanisms3()
        {
            var mechanisms = XmppXElement.LoadXml(Resource.Get("Xmpp.Sasl.mechanisms3.xml")).ShouldBeOfType<Mechanisms>();
            Assert.Equal("auth43.us.example.com", mechanisms.PrincipalHostname);
        }
    }
}
