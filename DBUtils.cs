using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingFund
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string server = "DESKTOP-BP1NIOC";
            string database = "HousingStockAccounting";
            return DBSQLServerUtils.GetDBConnection(server, database);
        }        
    }
}
