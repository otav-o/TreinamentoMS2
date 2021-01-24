using System;
using System.Data.SqlClient;

namespace UsandoADOdotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var conexao = new SqlConnection(@"Data Source=OTAVIO-VIVOBOOK\SQLEXPRESS;Initial Catalog=Aula16-TestesManager;Integrated Security=SSPI;"); 
            // é diferente da classe MySqlConnection (deve-se instalar o provider)
            // ADO.NET: biblioteca com funções e classes importantes para acessar BD em C#. É importante saber e tem maior desempenho
            // recomendado se não for usar um framework de persistência

            // declarar uma variável dentro do using: significa que no final do bloco não se precisa mais do objeto
            // no final chama o Dispose() e fecha automaticamente
            conexao.Open();
            conexao.Close();

            using (conexao = new SqlConnection(@"Data Source=OTAVIO-VIVOBOOK\SQLEXPRESS;Initial Catalog=Aula16-TestesManager;Integrated Security=SSPI;"))
            {
                conexao.Open();

                var sqlInserir = "insert into produto (id_produto, codigo, descricao, preco) values ('ABF', 4, 'Batata Frita', 35.5)";
                var cmdInserir = new SqlCommand(sqlInserir, conexao);
                cmdInserir.ExecuteNonQuery(); // executa um comando sem retorno (insert, delete, update)

                conexao.Close();
            }
            Console.WriteLine("Fim do programa");
        }
    }
}
