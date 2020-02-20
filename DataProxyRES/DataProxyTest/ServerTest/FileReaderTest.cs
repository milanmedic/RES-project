using Common;
using NUnit.Framework;
using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    [TestFixture]
    public class FileReaderTest
    {
        [Test]
        public void FileReader_ReadFromFile()
        {
            //Arrange
            FileReader fr = new FileReader();
            File.Delete(fr.File);
            List<Entry> l = new List<Entry>();
            l.Add(new Entry("01", 3000, "SRB"));
            l.Add(new Entry("02", 3000, "MKD"));
            using (StreamWriter sw = new StreamWriter(fr.File))
            {
                sw.WriteLine("Sat,Load,Oblast");
                sw.WriteLine("1,3000,SRB");
                sw.WriteLine("2,3000,MKD");
            }

            //Act
            fr.readFromFile();

            //Post act arrange
            //foreach(var a in fr.EntriesData)
            //{
            //    a.Hour = Convert.ToString(a.Hour[1]);
            //}
            //Assert
            CollectionAssert.AreEqual(l, fr.EntriesData);

            //Post assert cleanup
            File.Delete(fr.File);
        }
    }
}
