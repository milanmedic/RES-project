using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class FileReader : IFileReader
    {
        string file;
        List<Entry> entriesData = new List<Entry>();
        public string File { get => file; set => file = value; }
        public List<Entry> EntriesData { get => entriesData; set => entriesData = value; }

        public List<Entry> readFromFile()
        {
            
            using (var reader = new StreamReader(File)) // napraviti da preskace prvu liniju u csv-u
            {
                /* napraviti da preskace prvu liniju*/
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[1] != "")
                    {
                        int a;
                        EntriesData.Add(new Entry((values[0].Length == 1)?$"0{values[0]}" : values[0], ( (a = Int32.Parse(values[1]))<0)?0:a, values[2]));
                    }
                    else
                    {
                        string path = "../../../Logs/missingConsumption.txt";
                        string createText = $"{values[0]}h {DateTime.Now.ToString("dd.MM.yyy")}" +
                                            $" | Consumption: NaN | Area: {values[2]}\r\n";
                        
                        if (!System.IO.File.Exists(path))
                        {
                            System.IO.File.WriteAllText(path, createText);
                        }
                        else
                        {
                            System.IO.File.AppendAllText(path, createText);
                        }
                    }
                }
            }
            return EntriesData;
        }

        public FileReader()
        {
            //File = "../../../Data/test.csv";
            File = @"C:\Users\Nikola\source\repos\RES_Projekat_12-49_v2\DataProxyRES\Data\test.csv";
        }
    }
}
