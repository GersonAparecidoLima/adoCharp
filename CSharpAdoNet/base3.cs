using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdoNet
{
    class base3
    {
        
        public static void menu()
        {
           

            Console.WriteLine("===============Controle de Cliente===============");
            Console.WriteLine("Selecione uma Opção");
            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Visualizar");
            Console.WriteLine("Opção:");

            //recebendo e convertendo em número inteiro
            int opc = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            string title = string.Empty;
            switch (opc)
            {
                case 1:
                     title = "Listagem de Cliente";
                    Console.WriteLine("===============Listagem de Cliente===============");
                    ListarClientes();
                    break;
                case 2:
                    title = "Novo ";
                    Console.WriteLine("===============Controle de Cliente===============");
                    Console.Write("Informe um nome : ");
                    string nome = Console.ReadLine();

                    Console.Write("Informe um e-mail : ");
                    string email = Console.ReadLine();

                    SalvarClientes(nome, email);
                    break;

                case 3:
                    title = "Alteração de Cliente ";
                    Console.WriteLine("===============Alterar de Cliente===============");

                    ListarClientes();
                    Console.Write("Selecione um cliente pelo Id");
                    //recupereando o id digitado
                    int idOp = Convert.ToInt32(Console.ReadLine());
                    (int _id, string _nome, string _email) = SelecionarCliente(idOp);
                    //Limpando tela
                    Console.Clear();

                    //$ para interpolar
                    Console.WriteLine($"Alteração de Cliente - {_nome}");

                    Console.Write("Informe um nome : ");
                    nome = Console.ReadLine();

                    Console.Write("Informe um e-mail : ");
                    email = Console.ReadLine();

                    // verifica se nome e vazio, o nome vai receber o que vem do banco se não vai receber o que vem do banco de dados
                    nome = nome.Equals("") ? _nome:nome;
                    email = email.Equals("") ? _email : email;

                    SalvarClientes(nome, email, idOp);

                    Console.WriteLine($"Alteração de Cliente - {_nome}");



                    break;
                case 4:
                    title = "Exclusão de Cliente ";
                    Console.WriteLine("===============Exclusão de Cliente===============");

                    ListarClientes();
                    Console.Write("Selecione um cliente pelo Id");
                    //recupereando o id digitado
                    idOp = Convert.ToInt32(Console.ReadLine());
                    (_id, _nome, _email) = SelecionarCliente(idOp);
                    //Limpando tela
                    Console.Clear();
                    //$ para interpolar
                    Console.WriteLine($"Exclusão de Cliente - {_nome}");
                    Console.WriteLine("\n**************Atenção**************\n");
                    Console.WriteLine("Deseja continuar? (S para sim), (N para não)");
                    string confirmar = Console.ReadLine().ToUpper();
                    if (confirmar.Equals("S"))
                    {
                        DeletarClientes(idOp);
                    }





                    break;
                case 5:
                    title = "Visualização de Cliente ";
                    Console.WriteLine("===============Ver detalhe de Cliente============");

                    ListarClientes();
                    Console.Write("Selecione um cliente pelo Id : ");
                    //recupereando o id digitado
                    idOp = Convert.ToInt32(Console.ReadLine());
                    (_id, _nome, _email) = SelecionarCliente(idOp);
                    //Limpando tela
                    Console.Clear();
                    //$ para interpolar
                    Console.WriteLine($"Ver detalhe de Cliente - {_nome}");

                    Console.WriteLine("ID : {0}", _id );
                    Console.WriteLine("ID : {0}", _nome);
                    Console.WriteLine("ID : {0}", _email);


                    break;
                default:
                    title = "Opção Inválida ";
                    Console.WriteLine("===============Selecione uma Opção Valadia=======");
                    break;

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




        //sobrecarga 
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

        //sobrecarga 
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

        static (int, string, string) SelecionarCliente(int id) {
            //@ para tratamento das barras
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\gerson.lima\source\repos\AprendendoAdo\CSharpAdoNet\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            //abrindo conexão
            conn.Open();
            //objeto para executar comando no banco de dados
            // ou seja criando um novo comando para conn
            SqlCommand cmd = conn.CreateCommand();
            //CommandText e atributo que vai receber o sql vai ser executado
            cmd.CommandText = "select * from clientes where id = @id order by id";
            cmd.Parameters.AddWithValue("@id", id);

            //objeto para SqlDataReader fazer a leitrua de dados
            //ExecuteReader e como se fizesse a leitura do banco
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                dr.Read();

                //convertendo obj para 
                return (Convert.ToInt32(dr["id"].ToString()),dr["nome"].ToString(),dr["email"].ToString() );
                 
                
            }

        }



        public static void ListarClientes()
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
                cmd.CommandText = "select * from clientes order by id";

                //objeto para SqlDataReader fazer a leitrua de dados
                //ExecuteReader e como se fizesse a leitura do banco
                using (SqlDataReader dr = cmd.ExecuteReader())
                {

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
