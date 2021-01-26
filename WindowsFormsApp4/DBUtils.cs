using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //DESKTOP-BP1NIOC
            string datasource = @"DESKTOP-PPOTBC4\SQLEXPRESS";

            string database = "CinemaOnline";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }
}
