using XmppDotNet.Xml;
using XmppDotNet.Xmpp.Muc.User;
using Shouldly;
using Xunit;

namespace XmppDotNet.Tests.Xmpp.Muc.User
{
    public class ActorTest
    {
        [Fact]
        public void ShoudBeOfTypeActor()
        {
            XmppXElement.LoadXml(Resource.Get("Xmpp.Muc.User.actor1.xml")).ShouldBeOfType<Actor>();
        }

        [Fact]
        public void TestActor()
        {
            var a = XmppXElement.LoadXml(Resource.Get("Xmpp.Muc.User.actor1.xml")).Cast<Actor>();
            Assert.True(a.Jid.Equals("bard@shakespeare.lit"));
        }

        [Fact]
        public void TestBuildActor()
        {
            var act = new Actor("bard@shakespeare.lit");
            act.ShouldBe(Resource.Get("Xmpp.Muc.User.actor1.xml"));
        }       
    }
}
