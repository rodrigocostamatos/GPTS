using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{
    public class Conexao
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }
        //public const String CONEXAOGPTS = @"Data Source=NOTE01-PC;Initial Catalog=GPTS;User ID=sa;Password=P@ssw0rd";
        //public static String connectionString = @"Data Source=localhost;Initial Catalog=CERBERUS_2002;User ID=sa;Password=P@ssw0rd";
    }
}
