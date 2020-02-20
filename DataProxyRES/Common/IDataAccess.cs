using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IDataAccess
    {
        void writeToDB();
        List<Entry> readFromDB(DateTime datumOd, DateTime datumDo);
    }
}
