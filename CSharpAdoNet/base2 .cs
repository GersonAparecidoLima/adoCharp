using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpAdoNet
{
    class base2
    {
        public static void SelectPrimitivo2() {
            ListarClientes();
            Console.ReadKey();
            //Console.ReadLine();
        }


        public static void SalvarClientes(string nome, string email)
        {
            // vou pegar a minha string de conexão
            string connString = getStringConn();
            //using e para tudo que estiver dentro do parentes só vai ser instanciado quano estiver dentro da chave.
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //abrindo conexão
                conn.Open();
                //objeto para executar comando no banco de dados
                // ou seja criando um novo comando para conn
                SqlCommand cmd = conn.CreateCommand();
                //CommandText e atributo que vai receber o sql vai ser executado
                cmd.CommandText = "insert into clientes (nome, email) values (@nome, @email)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                //vai executar algo que não e uma consuta
                cmd.ExecuteNonQuery();
            }

        }

        public static void SalvarClientes(string nome, string email, int id)
        {
            // vou pegar a minha string de conexão
            string connString = getStringConn();
            //using e para tudo que estiver dentro do parentes só vai ser instanciado quano estiver dentro da chave.
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //abrindo conexão
                conn.Open();
                //objeto para executar comando no banco de dados
                // ou seja criando um novo comando para conn
                SqlCommand cmd = conn.CreateCommand();
                //CommandText e atributo que vai receber o sql vai ser executado
                cmd.CommandText = "update clientes set nome = @nome, email = @email where id = @id";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);
                //vai executar algo que não e uma consuta
                cmd.ExecuteNonQuery();
            }

        }



        public static void DeletarClientes(int id)
        {
            // vou pegar a minha string de conexão
            string connString = getStringConn();
            //using e para tudo que estiver dentro do parentes só vai ser instanciado quano estiver dentro da chave.
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //abrindo conexão
                conn.Open();
                //objeto para executar comando no banco de dados
                // ou seja criando um novo comando para conn
                SqlCommand cmd = conn.CreateCommand();
                //CommandText e atributo que vai receber o sql vai ser executado
                cmd.CommandText = "delete from clientes where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                //vai executar algo que não e uma consuta
                cmd.ExecuteNonQuery();
            }

        }








        public static void ListarClientes() {
            // vou pegar a minha string de conexão
            string connString = getStringConn();
            //using e para tudo que estiver dentro do parentes só vai ser instanciado quano estiver dentro da chave.
            using (SqlConnection conn = new SqlConnection(connString)) {
                //abrindo conexão
                conn.Open();
                //objeto para executar comando no banco de dados
                // ou seja criando um novo comando para conn
                SqlCommand cmd = conn.CreateCommand();
                //CommandText e atributo que vai receber o sql vai ser executado
                cmd.CommandText = "select * from clientes order by id";

                //objeto para SqlDataReader fazer a leitrua de dados
                //ExecuteReader e como se fizesse a leitura do banco
                using (SqlDataReader dr = cmd.ExecuteReader()){

                    //Read e a para fazer a leitura
                    //ele vai ir item por item até chegar no fim 
                    while (dr.Read())
                    {
                        Console.WriteLine("ID {0}", dr["id"]);
                        Console.WriteLine("Nome {0}", dr["nome"]);
                        Console.WriteLine("Email {0}", dr["email"]);
                        Console.WriteLine("------------------------");
                    }
                    conn.Close();
                }
            }

        }


        static string getStringConn()
        {
            //@ para tratamento das barras
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\gerson.lima\source\repos\AprendendoAdo\CSharpAdoNet\Database1.mdf;Integrated Security=True";
            return connString;
        }


    }


}
