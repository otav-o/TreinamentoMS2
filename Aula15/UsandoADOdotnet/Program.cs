using System;
using System.Data;
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

                //var sqlInserir = "insert into produto (id_produto, codigo, descricao, preco) values ('ABF', 4, 'Batata Frita', 35.5)";
                //var cmdInserir = new SqlCommand(sqlInserir, conexao);
                //cmdInserir.ExecuteNonQuery(); // executa um comando sem retorno (insert, delete, update)

                // --

                //var cmd = new SqlCommand("select * from produto", conexao);
                //var da = new SqlDataAdapter(cmd); // preenche o dataset quando chama o .Fill()
                //DataSet ds = new DataSet(); // classe padrão para todos os bancos

                //da.Fill(ds); // da executa o comando cmd na conexão e retorna no ds
                //conexao.Close();

                //foreach (DataRow reg in ds.Tables[0].Rows) // pega as linhas da primeira tabela (0)
                //{
                //    Console.Write($"{reg["id_produto"]}");
                //    Console.WriteLine($"{reg["codigo"]}, {reg["preco"]:C2}");
                //    Console.Write($"{reg["descricao"]}");
                //}

                //// para preencher um DS, precisa-se de um DataAdapter (que sabe executar comandos no SQL)

                // --

                Console.WriteLine("Informe parte da descrição do produto desejado: ");
                var parteDescricao = Console.ReadLine();
                var sqlQuery = $"select * from produto where descricao like '%{parteDescricao}%'";
                // concatenar strings do usuário: falha de segurança ex.: ';delete from produto where codigo = 4--
                var cmd = new SqlCommand(sqlQuery, conexao);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow reg in dt.Rows)
                {
                    Console.Write($"{reg["id_produto"]}, ");
                    Console.WriteLine($"{reg["codigo"]}, {reg["descricao"]}, {reg["preco"]:C2}");
                }

                conexao.Close();
            }
            Console.WriteLine("Fim do programa");
        }
    }
}
