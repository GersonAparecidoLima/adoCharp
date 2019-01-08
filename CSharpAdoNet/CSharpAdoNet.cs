using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;


namespace CSharpAdoNet
{
    class CSharpAdoNet
    {
        static void Main(string[] args)
        {
            //Primeira etapa da curso
            //base1.SelectPrimitivo();

            //Segunda Parte etapa da curso
            // base2.SelectPrimitivo2();

            //Segunda Parte etapa da curso
            //base2.SalvarClientes("Raimundo", "raimundo@pos.com.br");

            //sobrecarga no método
            //base2.SalvarClientes("Vania", "vania@pos.com.br", 2);

            // base2.DeletarClientes(4);
            //base2.SelectPrimitivo2();


            base3.menu();
            Console.ReadKey();
        }



    }
}
