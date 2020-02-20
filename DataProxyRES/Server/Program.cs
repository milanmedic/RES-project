using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess da = new DataAccess();
            da.writeToDB();
            //DataProxyDbContext context = new DataProxyDbContext();

            //Console.WriteLine("\n\n----------------------------\n");
            //foreach (var bla in context.Entries.ToArray())
            //{
            //    Console.WriteLine($"{bla.Area}, {bla.Consumption}, {bla.Hour}");
            //}

            //Console.WriteLine("Vidi mama radim");

            var dp = new DataProxy();
            //List<Entry> test;
            /*test = dp.requestData(DateTime.Parse("05.06.2018"), DateTime.Parse("07.06.2018"));
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }*/
            //test = dp.requestData("06.06.2018", "06.06.2018");
            //foreach (var item in test)
            //{
            //    Console.WriteLine(item);
            //}
            //test = dp.requestData("05.06.2018", "06.06.2018");
            //foreach (var item in test)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
