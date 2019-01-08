using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpAdoNet
{
    class base1
    {
        public static void SelectPrimitivo() {

            //@ para tratamento das barras
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\gerson.lima\source\repos\AprendendoAdo\CSharpAdoNet\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            //abrindo conexão
            conn.Open();
            //objeto para executar comando no banco de dados
            // ou seja criando um novo comando para conn
            SqlCommand cmd = conn.CreateCommand();
            //CommandText e atributo que vai receber o sql vai ser executado
            cmd.CommandText = "select * from clientes order by id";

            //objeto para SqlDataReader fazer a leitrua de dados
            //ExecuteReader e como se fizesse a leitura do banco
            SqlDataReader dr = cmd.ExecuteReader();

            //Read e a para fazer a leitura
            //ele vai ir item por item até chegar no fim 
            while (dr.Read())
            {
                Console.WriteLine( "ID {0}", dr["id"]);
                Console.WriteLine("Nome {0}", dr["nome"]);
                Console.WriteLine("Email {0}", dr["email"]);
                Console.WriteLine("------------------------");
            }
            Console.ReadKey();
        }

    }
}
