using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.IO;
using System.Data.Entity;

namespace Server
{
    public class DataAccess : IDataAccess
    {
        public List<Entry> readFromDB(DateTime datumOd, DateTime datumDo)
        {
            var context = new DataProxyDbContext();
            //Console.WriteLine(datumOd);
            var data = context.Entries
                .Where(x => (((DbFunctions.TruncateTime(x.Datum) >= DbFunctions.TruncateTime(datumOd)) && 
                              (DbFunctions.TruncateTime(x.Datum) <= DbFunctions.TruncateTime(datumDo)))))
                .ToList();
            //var data = context.Entries.Where(x => x.Datum >= datumOd && x.Datum <= datumDo).ToList();
            //DbFunctions.TruncateTime(datumDo);
            return data;//.ToList();
        }

        public void writeToDB()
        {
            var fr = new FileReader();
            var context = new DataProxyDbContext();
            var data = fr.readFromFile();

            foreach (var entry in data)
            {
                if (!context.Entries.ToList().Contains(entry))
                {
                    var postoji = context.Regions
                        .Where(x => x.Id == entry.Area)
                        .Count();

                    if(postoji == 0)
                    {
                        string path = "../../../Logs/MissingArea.txt";

                        if (!File.Exists(path))
                        {
                            File.WriteAllText(path, $"Missing area in DB: {entry.Area}");
                        }
                        else
                        {
                            File.AppendAllText(path, $"Missing area in DB: {entry.Area}");
                        }
                    }
                    else
                    {
                        context.Entries.Add(entry);
                    }
                }
                else
                {
                    string path = "../../../Logs/AlreadyExists.txt";

                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, entry.ToString());
                    }
                    else
                    {
                        File.AppendAllText(path, entry.ToString());
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
