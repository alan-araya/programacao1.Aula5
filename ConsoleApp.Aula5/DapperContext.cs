using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ConsoleApp.Aula5.DTO;

namespace ConsoleApp.Aula5
{
    public class DapperContext
    {
        private const string stringDeConexao = @"Server=database-aula.cg8lcumypg6o.us-east-2.rds.amazonaws.com;Port=3306;Database=dbaula;User Id=admin;Password=9b&bdWB5Aw^1;";

        public async Task<bool> InserirAutorAsync(Autor autor)
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"INSERT INTO Autores
                                 VALUES(@nome, @weburl);";

                    await dbConnection.ExecuteAsync(query, autor);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir o autor. Erro: " + ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateAutorAsync(Autor autor)
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"UPDATE Autores
                                    SET Nome = @nome, 
                                        WebUrl = @weburl
                                    WHERE AutorId = @autorid";

                    await dbConnection.ExecuteAsync(query, autor);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar o autor. Erro: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAutorAsync(int autorId)
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"DELETE FROM Autores
                                    WHERE AutorId = @autorid";

                    await dbConnection.ExecuteAsync(query, autorId);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar o autor. Erro: " + ex.Message);
                return false;
            }
        }

        public async Task<List<Autor>> ListaTodosAutores()
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"SELECT * FROM Autores";

                    var resultado = await dbConnection.QueryAsync<Autor>(query);
                    
                    return resultado.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar os dados no BD. Erro: " + ex.Message);
                return new List<Autor>();
            }
        }

        public async Task<List<LivroBaixaPontuacaoDTO>> ListaTop3LivrosPoucoAvaliadosEReviews()
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"SELECT 
		                                    r2.ReviewId,
	                                        r2.NomeRevisor,
	                                        r2.QtdEstrelas,
	                                        r2.Comentario,
	                                        l1.*
	                                FROM
		                            (
			                           SELECT
				                             l.LivroId, 
                                             l.Titulo, 
                                             (
				                                SELECT
					                                SUM(r.QtdEstrelas)
				                                FROM Review as r
				                                WHERE
					                                 r.LivroId = l.LivroId
                                             ) as 'QtdPontuacao'
			                                 FROM
				                                Livros AS l
			                                ORDER BY QtdPontuacao ASC
			                                LIMIT 3
		                                    ) as l1
	                                    LEFT JOIN 
	                                    ( 
		                                    SELECT * 
                                            FROM Review as rv
		                                    WHERE  rv.QtdEstrelas <= 3
	                                    ) as r2 on l1.LivroId = r2.LivroId;";

                    var resultado = await dbConnection.QueryAsync<LivroBaixaPontuacaoDTO>(query);

                    return resultado.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar os dados no BD. Erro: " + ex.Message);
                return new List<LivroBaixaPontuacaoDTO>();
            }
        }

        public async Task<List<LivroPontuacaoPorAnoDTO>> ListaLivrosPorAnoEPontuacao()
        {
            try
            {
                using (var dbConnection = new MySqlConnector.MySqlConnection(stringDeConexao))
                {
                    string query = @"   SELECT l2.LivroId,
	                                           l2.Titulo, 
	                                           l2.Descricao,
	                                           YEAR(l2.PublicadoEm) as 'AnoPublicacao',
	                                           SUM(r.QtdEstrelas) as 'Pontuacao',
	                                           AVG(r.QtdEstrelas) as 'Media'
                                        FROM Livros l2
                                        LEFT JOIN Review r ON r.LivroId = l2.LivroId
                                        WHERE r.QtdEstrelas >= 3
                                        GROUP BY l2.LivroId,
		                                         l2.Titulo,
		                                         l2.Descricao,
		                                         YEAR(l2.PublicadoEm)
                                        ORDER BY Media DESC;";

                    var resultado = await dbConnection.QueryAsync<LivroPontuacaoPorAnoDTO>(query);

                    return resultado.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar os dados no BD. Erro: " + ex.Message);
                return new List<LivroPontuacaoPorAnoDTO>();
            }
        }
    }
}
