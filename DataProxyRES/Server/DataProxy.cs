using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class DataProxy : IDataProxy
    {
        Dictionary<int, List<Entry>> localDB = new Dictionary<int, List<Entry>>();
        public List<Entry> requestData(DateTime datumOd, DateTime datumDo)
        {
            var data = new List<Entry>();

            var kljuc = (datumOd.ToString("dd.MM.yyy") + datumDo.ToString("dd.MM.yyy")).GetHashCode();

            if (localDB.ContainsKey(kljuc))
            {
                data = localDB[kljuc];
                Console.WriteLine("Imam to!");
            }
            else
            {
                var da = new DataAccess();
                data = da.readFromDB(DateTime.Parse(datumOd.ToString("dd.MM.yyy")), DateTime.Parse(datumDo.ToString("dd.MM.yyy")));
                Console.WriteLine("Kontaktirao sam DB!");
                localDB.Add(kljuc, data);
            }

            return data;
        }
    }
}
