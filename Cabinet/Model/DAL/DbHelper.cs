using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Model.DAL
{
    internal class DbHelper
    {
        public static SqlConnection Connection = new SqlConnection
            (@"Server=DESKTOP-ND1IOQ4;Database=CabinetDb;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
