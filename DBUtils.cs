using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string server = "DESKTOP-BP1NIOC";
            string database = "Timetable";
            return DBSQLUtils.GetDBConnection(server, database);
        }
    }
}
