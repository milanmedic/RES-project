using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Region
    {
        public string Id { get; set; }
        public string Naziv { get; set; }

        public Region()
        {
            Id = "";
            Naziv = "";
        }
    }
}
