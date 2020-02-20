using Common;
using NUnit.Framework;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    [TestFixture]
    public class DataProxyTest
    {
        [Test]
        [TestCase(null, null)]
        [TestCase(null, "10.5.2018")]
        [TestCase("10.5.2018", null)]
        public void requestDataTestNull(DateTime datumOd, DateTime datumDo)
        {
            Assert.Throws<AssertionException>(() => {
                Assert.IsNull(datumDo);
                Assert.IsNull(datumOd);
            });
            DataProxy dp = new DataProxy();
            try
            {
            List<Entry> lista = dp.requestData(datumOd, datumDo);
            }
            catch (Exception) { }
        }

        [Test]
        [TestCase("10.5.2018", "10.5.2018")]
        public void requestDataTestPass(string sdatumOd, string sdatumDo)
        {
            DateTime datumOd = DateTime.Parse(sdatumOd);
            DateTime datumDo = DateTime.Parse(sdatumDo);
            Assert.Throws<AssertionException>(() => {
                Assert.IsNull(datumDo);
                Assert.IsNull(datumOd);
            });
            DataProxy dp = new DataProxy();
            try
            {
                List<Entry> lista = dp.requestData(datumOd, datumDo);
            }
            catch (Exception) { }
            Assert.Pass();
        }

        [Test]
        [TestCase("32.5.2018", "10.5.2018")]
        [TestCase("2.5.2018", "10.15.2018")]
        public void requestDataTestFail(string sdatumOd, string sdatumDo)
        {
            DateTime datumDo;
            DateTime datumOd;

            bool dtOd = DateTime.TryParse(sdatumOd, out datumOd);
            bool dtDo = DateTime.TryParse(sdatumDo, out datumDo);

            Assert.Throws<AssertionException>(() => {
                Assert.IsFalse(dtOd);
                Assert.IsFalse(dtDo);
            });
            DataProxy dp = new DataProxy();
            try
            {
                List<Entry> lista = dp.requestData(datumOd, datumDo);
            }
            catch (Exception) { }
        }
    }
}