using CamadaAcessoADados.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            var sql = "insert into produto" +
                " (id_produto, codigo, descricao, preco)" +
                " values(@id_produto, @codigo, @descricao, @preco)";

            ExecutarComando(sql, produto, AdicionarParametrosTodos);

        }
        public void Atualizar(Produto produto)
        {

            var sql = "update produto" +
                " set codigo=@codigo, descricao=@descricao, preco=@preco" +
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
                " where id_produto=@id_produto";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("id_produto", id)
            };

            var resultados = ExecutarConsulta(sql, parametros);

            if (resultados.Count == 0) // se não encontrar um produto
                return null;

            return resultados[0];

        }
        public IList<Produto> RetornarPorParteDescricao(string parteDescricao)
        {
            var sql = "select * from produto where descricao like @descricao";

            var parametros = new SqlParameter[] { new SqlParameter("Descricao", "%" + parteDescricao + "%") };

            return ExecutarConsulta(sql, parametros);
        }

        private IList<Produto> ExecutarConsulta(string sql, IEnumerable<SqlParameter> parametros)
        {
            using (var conexao = new SqlConnection(strConexao))
            {
                conexao.Open();

                var cmd = new SqlCommand(sql, conexao);

                cmd.Parameters.AddRange(parametros.ToArray());

                var registros = new DataTable();

                var da = new SqlDataAdapter(cmd); 

                da.Fill(registros); // da preenche o DataTable

                conexao.Close();

                return DeserializarTabela(registros); // função que recebe o dataTable e retorna uma lista de produtos
            }
        }
        private IList<Produto> DeserializarTabela(DataTable regs)
        {
            var objetos = new List<Produto>();
            foreach (DataRow reg in regs.Rows)
            {
                objetos.Add(DeserializarLinha(reg));
                
            }
            return objetos;
        }
        private Produto DeserializarLinha(DataRow reg)
        {
            var obj = new Produto();
            obj.ProdutoId = reg["id_produto"].ToString(); // converter para string pois DT retorna um object
            obj.Codigo = Convert.ToInt32(reg["codigo"]); // ou registros.Rows[0]
            obj.Descricao = reg["descricao"].ToString();
            obj.Preco = Convert.ToDouble(reg["preco"]);

            return obj;
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
