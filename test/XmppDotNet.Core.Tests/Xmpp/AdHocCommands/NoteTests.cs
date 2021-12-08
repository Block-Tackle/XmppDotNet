using XmppDotNet.Xml;
using XmppDotNet.Xmpp.AdHocCommands;
using Xunit;
using Shouldly;

namespace XmppDotNet.Tests.Xmpp.AdHocCommands
{
    
    public class NoteTests
    {
        private const string VALUE = "Service 'httpd' has been configured.";
        private const string XML1 = @"<note xmlns='http://jabber.org/protocol/commands' type='info'>" + VALUE + "</note>";
        
        [Fact]
        public void Test1()
        {
            XmppXElement xmpp1 = XmppXElement.LoadXml(XML1);

            xmpp1.ShouldBeOfType<Note>();

            var note = xmpp1 as Note;
            if (note != null)
            {
                note.Value.ShouldBe(VALUE);
                note.Value.ShouldNotBe("dummy");
                note.Type.ShouldBe(NoteType.Info);
                note.Type.ShouldNotBe(NoteType.Error);
                note.Type.ShouldNotBe(NoteType.Warn);
            }
        }

        [Fact]
        public void Test2()
        {
            var note = new Note()
            {
                Type = NoteType.Info,
                Value = VALUE
            };

            note.ShouldBe(XML1);
        }
    }
}
