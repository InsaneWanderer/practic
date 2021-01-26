using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable
{
    class DBSQLUtils
    {
        public static SqlConnection GetDBConnection(string server, string database)
        {
            string connString = "Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
