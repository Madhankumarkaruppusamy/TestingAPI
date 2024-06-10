using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Repositories;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _student;

        public StudentController(IStudentRepository student)
        {
            _student = student;
        }

        [HttpGet]
        [Route("getstudentdetail")]
        public dynamic GetStudentDetail()
        { 
            try
            {
                var student = _student.ReadStudent();
                return student.ToList();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        [HttpPost]
        [Route("addstudentdetail")]
        public dynamic AddStudentDetail(Student input)
        {
            try
            {
                var student = _student.InsertStudent(input);
                return student;
            }
            catch (Exception ex)
            {
                return ex; 
            }
        }

        [HttpPut]
        [Route("updatestudentdetail/{Id}")]
        public dynamic UpdateStudentDetail(int Id, Student input)
        {
            try
            {
                var student = _student.UpdateStudent(Id, input);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return ex;
            }
         }

        [HttpDelete]
        [Route("deletestudentdetail/{Id}")]
        public dynamic DeleteStudentDetail(int Id)
        {
            try
            {
                _student.DeleteStudent(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
