using System;
using Xunit;
using Shouldly;
using Matrix.Xml;
using Matrix.Xmpp;
using Matrix.Xmpp.Client;
using Matrix.Xmpp.Ping;
using Matrix.Xmpp.Stream;

namespace Matrix.Tests.Xml
{
    public class ExtensionsTest
    {
        [Fact]
        public void TestMatchPredicates()
        {
            var pIq = new IqQuery<PingIq> {Type = IqType.Get, Id = "foo"};

            pIq.IsMatch(iq => iq.HasAttribute("id")).ShouldBeTrue();
            pIq.IsMatch(iq => iq.HasAttribute("foo")).ShouldBeFalse();


            pIq.IsMatch(el => el.OfType<Iq>()).ShouldBeTrue();

            pIq.IsMatch(el => el.OfType<Iq>() && el.Cast<Iq>().Id == "foo").ShouldBeTrue();
            pIq.IsMatch(el => el.OfType<Iq>() && el.Cast<Iq>().Id == "foo" && el.Cast<Iq>().Type == IqType.Get)
                .ShouldBeTrue();
            pIq.IsMatch(el => el.OfType<Iq>() && el.Cast<Iq>().Id == "foo" && el.Cast<Iq>().Type == IqType.Result)
                .ShouldBeFalse();
            

            Func<XmppXElement, bool> predicate1 = e => e.OfType<StreamFeatures>();
            var elSf = XmppXElement.LoadXml("<stream:features xmlns:stream='http://etherx.jabber.org/streams'/>");
            elSf.ShouldBeOfType<StreamFeatures>();
            elSf.IsMatch(predicate1).ShouldBeTrue();

            var iq2 = new Iq {Type = IqType.Get};

            iq2.IsMatch(el =>
                el.OfType<Iq>()
                && el.Cast<Iq>().Type == IqType.Get
                && el.Cast<Iq>().Query.OfType<Ping>()
            ).ShouldBeFalse();

            iq2.IsMatch(el =>
                el.OfType<Iq>()
                && el.Cast<Iq>().Type == IqType.Get
            ).ShouldBeTrue();
        }
    }
}
