using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    [TestFixture()]
    public class RegionTests
    {
        [Test]
        [TestCase("SRB", "Srbija")]
        public void RegionTest(string id, string naziv)
        {
            Region region = new Region();
            region.Id = id;
            region.Naziv = naziv;

            Assert.Throws<AssertionException>(() =>
            {
                Assert.IsNotNull(region);
                Assert.AreNotEqual(region.Id, "SRB");
                Assert.AreNotEqual(region.Naziv, "Srbija");
            });
        }
    }
}
