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
using System.IO;
using System.Diagnostics;
using Serilog;
using MyWebAppPracting.ModelDtos.ModelDtoUser;
using MyWebAppPracting.MyAttribues;
using Microsoft.AspNetCore.Authorization;

namespace MyWebAppPracting.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MyController : Controller
    {

        static bool check = true;
        public ILogger<MyController> logger { get; set; }
        public UnitOfWork UnitOfWork { get; set; }

        public MyController(UnitOfWork unitOfWorks, ILogger<MyController> logger)
        {
            UnitOfWork = unitOfWorks;
            this.logger = logger;
        }
        #region StudentCrudfunctionally



        [HttpGet("GetAllStudents")]
        [Authorize]
        public async Task<IEnumerable<Studentss>> GetAllStudents()
        {
            var user = HttpContext.User;

            Log.Logger.Information($"started GetAllStudentsRequest");
            var data = await UnitOfWork.Students.GetAll().ToListAsync();
            Log.Logger.Information($"finished GetAllStudentsRequest");
            return data;
        }


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
        public async Task AddStudent(StudentDto st)
        {
            var student = new Studentss()
            {
                Name = st.Name,
                Surname = st.Surname,
                GenId = st.GenId,
                IsDeleted = 0
            };
            await UnitOfWork.Students.Insert(student);
        }




        [HttpDelete("DeleteStudent")]
        public async Task DeleteStudent(int id) =>
          await UnitOfWork.Students.Delete(id);

        [HttpPut("UpdateStudent")]
        public async Task UpdateStudent(string name, string surname, int id)
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
