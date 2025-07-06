using ConcessionnaireAPI.Models;

namespace ConcessionnaireAPI.Repositories
{
    public interface IConcessionnaireRepository
    {
        public Task<IEnumerable<Concessionnaire>> GetAll();
        public Task<Concessionnaire> GetById(int id);
        public Task<Concessionnaire> Add(Concessionnaire concessionnaire);
        public Task<Concessionnaire> Update(int id, Concessionnaire concessionnaire);
        public Task DeleteById(int id);

    }
}
