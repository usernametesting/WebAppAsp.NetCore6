using MyWebAppPracting.Models;
using MyWebAppPracting.Models.ModelsMyFirstCodeDatabase;
using MyWebAppPracting.Models.ModelsUser;

namespace MyWebAppPracting.Reposters
{
    public interface IStudentReposter
    {
        Task<object> GetAll();
        Task<object> Add(Personeller st);
    }
}
