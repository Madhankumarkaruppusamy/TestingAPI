
using Microsoft.AspNetCore.Identity;
using Test.DBContext;

namespace Test.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _db;
        public StudentRepository(StudentDbContext db)
        {
            _db = db;
        }
        public dynamic ReadStudent()
        {
            try
            {

                IQueryable<Student> student = _db.Student;
                return student.ToList();
            }
            catch (Exception ex) 
            {
                return ex ;
            }
        }

        public dynamic InsertStudent(Student details)
        {
            try
            {
                var student = new Student
                {
                    StudentName = details.StudentName,
                    RollNumber = details.RollNumber,
                    EmailId = details.EmailId,
                    PhoneNumber = details.PhoneNumber,
                    City = details.City

                };

                _db.Student.Add(student);
                _db.SaveChanges();
                return 200;
            }
            catch (Exception ex) 
            {
                return ex;
            }
        }


        public dynamic UpdateStudent(int ID, Student details)
        {
            try
            {

                var result = _db.Student.Where(w => w.Id == details.Id).FirstOrDefault();
                result.StudentName = details.StudentName;
                result.RollNumber = details.RollNumber; 
                result.EmailId = details.EmailId;   
                result.PhoneNumber = details.PhoneNumber;
                result.City = details.City;


                _db.Student.Update(result);
                _db.SaveChanges();
                return 200;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public dynamic DeleteStudent(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
