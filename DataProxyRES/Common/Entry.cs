using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Entry
    {
        
        private string hour;
        private int consumption;
        private string area;

        public DateTime Datum { get; set; }

        public Entry()
        {

        }

        public Entry(string h, int c, string a)
        {
            try
            {
                this.hour = h + "h " + DateTime.Now.ToString("dd.MM.yyy"); // kljuc
                this.consumption = c;
                this.area = a;
                Datum = DateTime.Now.Date;
            }
            catch(ArgumentException)
            {

            }
        }
        [Key]
        public string Hour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
            }
        }
        public int Consumption
        {
            get
            {
                return this.consumption;
            }
            set
            {
                this.consumption = value;
            }
        }
        public string Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }

        public override string ToString()
        {
            return $"Timestamp: {hour}\t Consumption: {consumption}\t Area: {area}";
        }

        public override bool Equals(object obj)
        {
            var o = obj as Entry;
            return this.Hour == o.Hour;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
