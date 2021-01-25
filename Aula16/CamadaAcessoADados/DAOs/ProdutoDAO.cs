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
            var sql = "insert into produto " +
                "(id_produto, codigo, descricao, preco)" +
                "values(@id_produto, @codigo, @descricao, @preco)";

            ExecutarComando(sql, produto, AdicionarParametrosTodos);

        }
        public void Atualizar(Produto produto)
        {

            var sql = "update produto " +
                " set codigo=@codigo, descricao=@descricao, preco=@preco)" +
                " where id_produto=@id_produto";

            ExecutarComando(sql, produto, AdicionarParametrosTodos);
           
        }
        public void Excluir(Produto produto)
        {
            var sql = "delete from produto" +
                " where id_produto=@id_produto";

            ExecutarComando(sql, produto, AdicionarParametroId);
        }
        public Produto RetornarPorId(string id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Produto> RetornarPorParteNome(string parteNome)
        {
            throw new NotImplementedException();
        }
        private void ExecutarComando(string sql, Produto obj, Action<SqlCommand, Produto> AdicionarParametros)
        {
            using(var conexao = new SqlConnection(strConexao))
            {
                conexao.Open();
                var cmd = new SqlCommand(sql, conexao);

                AdicionarParametros(cmd, obj);

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        private void AdicionarParametrosTodos(SqlCommand cmd, Produto obj)
        {
            cmd.Parameters.AddWithValue("id_produto", obj.ProdutoId); // adiciona o id do objeto produto como parâmetro @id_produto
            cmd.Parameters.AddWithValue("codigo", obj.Codigo);
            cmd.Parameters.AddWithValue("descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("preco", obj.Preco);
        }
        private void AdicionarParametroId(SqlCommand cmd, Produto obj)
        {
            cmd.Parameters.AddWithValue("codigo", obj.ProdutoId);
        }



        private string strConexao = @"Data Source=OTAVIO-VIVOBOOK\SQLEXPRESS;Initial Catalog=Aula16-TestesManager;Integrated Security=SSPI;";
    }
}
