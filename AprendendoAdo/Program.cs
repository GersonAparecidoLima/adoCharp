using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using static System.Console;


namespace AprendendoAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            //@ para tratamento das barras
             string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\gerson.lima\source\repos\AprendendoAdo\AprendendoAdo\AprendendoAdo.mdf;Integrated Security=True"

            //SqlConnection 
        public static SqlConnection con = new SqlConnection(conStr);


        //armazenar os sql que vai executar no bd


        public SqlCommand cmd = con.CreateCommand();
    }
    }
}
