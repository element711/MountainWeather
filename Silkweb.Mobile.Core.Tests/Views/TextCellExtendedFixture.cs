using NUnit.Framework;
using Silkweb.Mobile.Core.Views;

namespace Silkweb.Mobile.Core.Tests.Views
{
    [TestFixture]
    public class TextCellExtendedFixture
    {
        [Test]
        public void ShowsDisclosure()
        {
            var textcell = new TextCellExtended();

            Assert.That(textcell.ShowDisclosure, Is.False);

            textcell.ShowDisclosure = true;

            Assert.That(textcell.ShowDisclosure, Is.True);
        }
    }
}

