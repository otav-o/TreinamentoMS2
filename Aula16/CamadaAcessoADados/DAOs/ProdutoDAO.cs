using CamadaAcessoADados.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CamadaAcessoADados.DAOs
{
    class ProdutoDAO
    {
        public void Inserir(Produto produto)
        {
            if (produto.ProdutoId == null)
                produto.ProdutoId = Guid.NewGuid().ToString(); // geração de número único no mundo
                                                               // melhor do que o id auto-increment pois precisaria buscar o último id gerado
            using (var conexao = new SqlConnection(strConexao))
            {
                conexao.Open();
                var sql = "insert into produto " +
                    "(id_produto, codigo, descricao, preco)" +
                    "values(@id_produto, @codigo, @descricao, @preco)";

                var cmd = new SqlCommand(sql, conexao); // cria o command

                cmd.Parameters.AddWithValue("id_produto", produto.ProdutoId); // adiciona o id do objeto produto como parâmetro @id_produto
                cmd.Parameters.AddWithValue("codigo", produto.Codigo);
                cmd.Parameters.AddWithValue("descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("preco", produto.Preco);

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }
        public void Atualizar(Produto produto)
        {
            using (var conexao = new SqlConnection(strConexao))
            {
                conexao.Open();
                var sql = "update produto " +
                    " set codigo=@codigo, descricao=@descricao, preco=@preco)" +
                    " where id_produto=@id_produto";

                var cmd = new SqlCommand(sql, conexao); // cria o command

                cmd.Parameters.AddWithValue("id_produto", produto.ProdutoId); // adiciona o id do objeto produto como parâmetro @id_produto
                cmd.Parameters.AddWithValue("codigo", produto.Codigo);
                cmd.Parameters.AddWithValue("descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("preco", produto.Preco);

                cmd.ExecuteNonQuery();

                conexao.Close();
            }

        }
        public void Excluir(Produto produto)
        {

        }
        public Produto RetornarPorId(string id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Produto> RetornarPorParteNome(string parteNome)
        {
            throw new NotImplementedException();
        }

        private string strConexao = @"Data Source=OTAVIO-VIVOBOOK\SQLEXPRESS;Initial Catalog=Aula16-TestesManager;Integrated Security=SSPI;";
    }
}
