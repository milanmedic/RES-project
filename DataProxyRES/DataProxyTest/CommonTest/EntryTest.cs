using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    [TestFixture]
    public class EntryTest
    {
        [Test]
        [TestCase("1", 3024, "MKD")]
        [TestCase("2", 200, "SRB")]
        [TestCase("3", 3024, "CRO")]
        [TestCase("4", 3024, "BIH")]
        public void goodEntryTest(string h, int c, string a)
        {
            Entry entry = new Entry(h, c, a);
            Entry e = new Entry();

            Assert.AreEqual(entry.Hour, h + "h " + DateTime.Now.ToString("dd.MM.yyy"));
            Assert.AreEqual(entry.Consumption, c);
            Assert.AreEqual(entry.Area, a);
        }

        [Test] 
        [TestCase("", "", "MKD")]
        [TestCase("2", "200", "SRB")]
        [TestCase("12495", "", "TUR")]
        [TestCase("1", "3024", "")]
        [TestCase("0", "23", "SRB")]
        [TestCase("2", "321", "")]
        [TestCase("3", "", "SRB")]
        public void badEntryTest(string h, string c, string a)
        {
            int o;
            Int32.TryParse(c, out o);
            Assert.Throws<AssertionException>(() =>
            {
                Assert.IsNotInstanceOf(typeof(string), h);
                Assert.True(Int32.TryParse(c, out o));
                Assert.IsNotInstanceOf(typeof(string), a);
                Assert.IsNotEmpty(h);
                Assert.Greater(Int32.Parse(h), 24);
                Assert.Less(Int32.Parse(h), 1);
                Assert.IsNotEmpty(a);
            });
            Entry entry = new Entry(h, o, a);
        }

        [Test]
        [TestCase(null, 2000, "MKD")]
        [TestCase("2", null, "SRB")]
        [TestCase("12495", 3024, null)]
        public void nullEntryTest(string h, int c, string a)
        {
            Assert.Throws<AssertionException>(() =>
            {
                Assert.AreEqual(h, null);
                Assert.AreEqual(h, "");
                Assert.AreEqual(c, null);
                Assert.AreEqual(a, null);
                Assert.AreEqual(a, "");
            });
            Entry entry = new Entry(h, c, a);
        }
    }
}
