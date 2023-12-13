using Microsoft.EntityFrameworkCore;
using MyWebAppPracting.Models.ModelsUser;

namespace MyWebAppPracting.Reposters
{
    public class StudentReposteriGeneric<TEntity> : IStudentReposteriGeneric<TEntity> where TEntity : class
    {
        public DbContext dbcontext { get; set; }
        public DbSet<TEntity> dbset { get; set; }

        public StudentReposteriGeneric(usersContext dbcontext)
        {
           
            this.dbcontext = dbcontext;
            dbset = this.dbcontext.Set<TEntity>();
        }

        public  IQueryable<TEntity> GetAll() => dbset;

        public async Task<TEntity> Get(int id) =>
            await dbset.FindAsync(id);

        public async Task Insert(TEntity entity)
        {
            await dbset.AddAsync(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Update(TEntity obj)
        {
            dbset.Update(obj);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            dbset.Remove(await Get(id));
            await dbcontext.SaveChangesAsync();

        }
        
    }
}
