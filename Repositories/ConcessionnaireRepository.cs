using ConcessionnaireAPI.Data;
using ConcessionnaireAPI.Models;
using Dapper;

namespace ConcessionnaireAPI.Repositories
{
    public class ConcessionnaireRepository : IConcessionnaireRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public ConcessionnaireRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<Concessionnaire> Add(Concessionnaire concessionnaire)
        {
            string sql = @"INSERT INTO Concessionnaires (Nom, Ville, Telephone, DateOuverture)
                            VALUES (@Nom, @Ville, @Telephone, @DateOuverture);
                            SELECT SCOPE_IDENTITY();";

            using (var db = _apiDbContext.CreateConnection()) 
            {
                concessionnaire.Id = await db.ExecuteScalarAsync<int>(sql, concessionnaire);
                return concessionnaire;
            }
        }

        public async Task DeleteById(int id)
        {
            string sql = "DELETE FROM Concessionnaires WHERE Id=@Id";
            using (var db = _apiDbContext.CreateConnection())
            {
                await db.ExecuteAsync(sql, new { Id = id });
            }

        }

        public async Task<IEnumerable<Concessionnaire>> GetAll()
        {
            string sql = "SELECT * FROM Concessionnaires";
            using (var db = _apiDbContext.CreateConnection())
            {
                var resultats = await db.QueryAsync<Concessionnaire>(sql);
                return resultats.ToList();
            }

        }

        public async Task<Concessionnaire> GetById(int id)
        {
            string sql = "SELECT * FROM Concessionnaires WHERE Id = @Id";
            using (var db = _apiDbContext.CreateConnection())
            {
                var resultat = await db.QueryFirstOrDefaultAsync<Concessionnaire>(sql, new { Id = id});
                return resultat;
            }
        }

        public async Task<Concessionnaire> Update(int id, Concessionnaire concessionnaire)
        {
            string sql = @"UPDATE Concessionnaires set Nom=@Nom, Ville=@Ville, 
                           Telephone=@Telephone, DateOuverture=@DateOuverture WHERE Id=@Id";

            using (var db = _apiDbContext.CreateConnection())
            {
                await db.ExecuteAsync(sql, concessionnaire);
                return concessionnaire;
            }
        }
    }
}
