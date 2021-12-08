using XmppDotNet.Xml;
using XmppDotNet.Xmpp;
using XmppDotNet.Xmpp.Dialback;
using Shouldly;
using Xunit;

namespace XmppDotNet.Tests.Xmpp.Dialback
{
    public class DialbackTest
    {
        [Fact]
        public void TestDialBackKeyGeneration()
        {
            var key = Verify.GenerateDialbackKey(
                "s3cr3tf0rd14lb4ck",
                "xmpp.example.com",
                "example.org",
                "D60000229F");

            key.ShouldBe("37c69b1cf07a3f67c04a5ef5902fa5114f2c76fe4a2686482ba5b89323075643");
        }
        
        [Fact]
        public void TestVerifyElement()
        {
            var xmpp1 = XmppXElement.LoadXml(Resource.Get("Xmpp.Dialback.stream.xml"));

            xmpp1.FirstElement.ShouldBeOfType<Verify>();

            var verify = xmpp1.FirstElement as Verify;
            verify.DialbackKey.ShouldBe("37c69b1cf07a3f67c04a5ef5902fa5114f2c76fe4a2686482ba5b89323075643");
            verify.Id.ShouldBe("D60000229F");
            verify.To.Equals("example.org").ShouldBeTrue();
            verify.From.Equals("xmpp.example.com").ShouldBeTrue();
        }

        [Fact]
        public void TypeTest()
        {
            var xmpp1 = XmppXElement.LoadXml(Resource.Get("Xmpp.Dialback.verify1.xml"));
            xmpp1.ShouldBeOfType<Verify>();
            xmpp1.Cast<Verify>().Type.ShouldBe(VerifyType.Valid);

            var xmpp2 = XmppXElement.LoadXml(Resource.Get("Xmpp.Dialback.verify2.xml"));
            xmpp2.ShouldBeOfType<Verify>();
            xmpp2.Cast<Verify>().Type.ShouldBe(VerifyType.Invalid);

            var xmpp3 = XmppXElement.LoadXml(Resource.Get("Xmpp.Dialback.verify3.xml"));
            xmpp3.ShouldBeOfType<Verify>();
            xmpp3.Cast< Verify>().Type.ShouldBe(VerifyType.None);
        }
        
        [Fact]
        public void TestBuildVerifyElement()
        {
            var expectedXml = Resource.Get("Xmpp.Dialback.stream.xml");
            var stream = new XmppDotNet.Xmpp.Server.Stream
            {
                To = "xmpp.example.com",
                From = "example.org",
                Id = "D60000229F"
            };
            stream.AddNameSpaceDeclaration("db", Namespaces.ServerDialback);

            var verify = new Verify
            {
                Id = "D60000229F",
                DialbackKey = "37c69b1cf07a3f67c04a5ef5902fa5114f2c76fe4a2686482ba5b89323075643",
                From = "xmpp.example.com",
                To = "example.org"
            };

            stream.Add(verify);
            stream.ShouldBe(expectedXml);
        }
      
        [Fact]
        public void TestBuildVerifyElement2()
        {
            var expectedXml = Resource.Get("Xmpp.Dialback.stream.xml");
            var stream = new XmppDotNet.Xmpp.Server.Stream
            {
                To = "xmpp.example.com",
                From = "example.org",
                Id = "D60000229F"
            };
            stream.AddDialbackNameSpaceDeclaration();

            var verify = new Verify
            {
                Id = "D60000229F",
                DialbackKey = "37c69b1cf07a3f67c04a5ef5902fa5114f2c76fe4a2686482ba5b89323075643",
                From = "xmpp.example.com",
                To = "example.org"
            };

            stream.Add(verify);
            stream.ShouldBe(expectedXml);
        }

        [Fact]
        public void TestBuildVerifyElement3()
        {
            var expectedXml = Resource.Get("Xmpp.Dialback.stream.xml");
            var stream = new XmppDotNet.Xmpp.Server.Stream(true)
            {
                To = "xmpp.example.com",
                From = "example.org",
                Id = "D60000229F"
            };

            var verify = new Verify
            {
                Id = "D60000229F",
                DialbackKey = "37c69b1cf07a3f67c04a5ef5902fa5114f2c76fe4a2686482ba5b89323075643",
                From = "xmpp.example.com",
                To = "example.org"
            };

            stream.Add(verify);
            stream.ShouldBe(expectedXml);
        }
    }
}
