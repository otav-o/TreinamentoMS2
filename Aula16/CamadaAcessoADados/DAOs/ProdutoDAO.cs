using CamadaAcessoADados.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            string sql = "select * from produto" +
                "where id_produto = @id";
            using (var conexao = new SqlConnection(strConexao))
            {
                var cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("id_produto", id);

                var registros = new DataTable();

                var da = new SqlDataAdapter(cmd);

                da.Fill(registros); // da preenche o DataTable

                conexao.Close();

                if (registros.Rows.Count == 0) // se não encontrar um produto
                    return null;

                var primeiraLinha = registros.Rows[0];

                var obj = new Produto();
                obj.ProdutoId = registros.Rows[0]["id_produto"].ToString(); // converter para string pois DT retorna um object
                obj.Codigo = Convert.ToInt32(primeiraLinha["codigo"]); // ou registros.Rows[0]
                obj.Descricao = primeiraLinha["descricao"].ToString();
                obj.Preco = Convert.ToDouble(registros.Rows[0]["preco"]);

                return obj; // retorna o produto
            }
            
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
