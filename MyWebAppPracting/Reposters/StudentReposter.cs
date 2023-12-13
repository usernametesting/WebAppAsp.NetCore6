using Microsoft.EntityFrameworkCore;
using MyWebAppPracting.Models;
using MyWebAppPracting.Models.ModelsMyFirstCodeDatabase;
using MyWebAppPracting.Models.ModelsUser;

namespace MyWebAppPracting.Reposters
{
    public class StudentReposter : IStudentReposter
    {
        public NorthwindContext dbcontext { get; }
        public StudentReposter(NorthwindContext context)
        {
            dbcontext = context;
        }


        public async Task<object> Add(Personeller st)
        {
            await dbcontext.Personellers.AddAsync(st);
            await dbcontext.SaveChangesAsync(); 
            return st;
        }

        public async Task<object> GetAll()
        {
            return await dbcontext.Personellers.ToListAsync();
        }
    }
}
