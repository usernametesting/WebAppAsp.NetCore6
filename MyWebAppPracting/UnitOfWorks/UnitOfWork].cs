using MyWebAppPracting.Models.ModelsUser;
using MyWebAppPracting.Reposters;
using System.Reflection.Metadata.Ecma335;

namespace MyWebAppPracting.UnitOfWorks
{
    public class UnitOfWork
    {
        public usersContext dbcontext { get; set; }

        private IStudentReposteriGeneric<Studentss> students;

        public IStudentReposteriGeneric<Studentss> Students
        {
            get
            {
                if (students == null)
                    return new StudentReposteriGeneric<Studentss>(dbcontext);
                return students;
            }

            set { students = value; }
        }

        private IStudentReposteriGeneric<Course> courses;

        public IStudentReposteriGeneric<Course> Courses
        {
            get
            {
                if (students == null)
                    return new StudentReposteriGeneric<Course>(dbcontext);
                return courses;
            }

            set { courses = value; }
        }


        public UnitOfWork(usersContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public void SaveChanges()=>
            dbcontext.SaveChanges();


    }
}
