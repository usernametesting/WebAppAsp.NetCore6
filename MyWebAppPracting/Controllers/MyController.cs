using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyWebAppPracting.Models;
using MyWebAppPracting.Models.ModelsUser;
using MyWebAppPracting.Reposters;
using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using MyWebAppPracting.UnitOfWorks;

namespace MyWebAppPracting.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MyController : Controller
    {
        public UnitOfWork UnitOfWork { get; }

        public MyController(UnitOfWork unitOfWorks)
        {
            UnitOfWork = unitOfWorks;
        }
        #region StudentCrudfunctionally

        [HttpGet("GetAllStudents")]
        public async Task<IEnumerable<object>> GetAllStudents() =>
            await UnitOfWork.Students.GetAll().ToListAsync();



        [HttpGet("GetAllStudentsWithCourses")]
        public async Task<IEnumerable<object>> GetAllStudentsWithCourses()
        {
            
            var query = UnitOfWork.Students.GetAll();
            var data = await query.Include(s => s.CoursesAndstudents).Select(st => new
            {
                st.Name,
                st.Surname,
                courses = st.CoursesAndstudents!.Select(s => s.Course).ToList(),
            }).ToListAsync();
            return data;
        }

        [HttpGet("GetStudent")]
        public async Task<object> GetStudent(int id) =>
            await UnitOfWork.Students.Get(id);



        [HttpPost("AddStudent")]
        public async Task AddStudent(Studentss st) =>
          await UnitOfWork.Students.Insert(st);




        [HttpDelete("DeleteStudent")]
        public async Task DeleteStudent(int id) =>
          await UnitOfWork.Students.Delete(id);

        [HttpPut("UpdateStudent")]
        public async Task UpdateStudent(string name,string surname, int id)
        {
            Studentss data = (Studentss)await UnitOfWork.Students.Get(id);
            data.Name = name;
            data.Surname = surname;
            await UnitOfWork.Students.Update(data);
        }

        #endregion

        #region CourseCrudFunctionally

        [HttpGet("GetAllCourses")]
        public async Task<IEnumerable<object>> GetAllCourses() =>
            await UnitOfWork.Courses.GetAll().ToListAsync();

        [HttpGet("GetCourse")]
        public async Task<object> GetCourse(int id) =>
            await UnitOfWork.Courses.Get(id);



        [HttpPost("AddCourse")]
        public async Task AddCourse(Course st) =>
          await UnitOfWork.Courses.Insert(st);




        [HttpDelete("DeleteCourse")]
        public async Task DeleteCourse(int id) =>
          await UnitOfWork.Courses.Delete(id);

        [HttpPut("UpdateCourse")]
        public async Task UpdateCourse(string name, int id)
        {
            Course data = ((Course)await UnitOfWork.Courses.Get(id));
            data.Name = name;
            await UnitOfWork.Courses.Update(data);
        }

        #endregion

    }

}
