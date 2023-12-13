using System.Linq;

namespace MyWebAppPracting.Reposters
{
    public interface IStudentReposteriGeneric<TEntity> where TEntity : class
    {

        public IQueryable<TEntity> GetAll();
        public Task<TEntity> Get(int id);
        public Task Insert(TEntity entity);
        public Task Update(TEntity obj);
        public Task Delete(int id);
    }
}
