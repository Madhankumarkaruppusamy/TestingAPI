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
            var student= _student.ReadStudent();
            return student.ToList();
        }

        [HttpPost]
        [Route("addstudentdetail")]
        public dynamic AddStudentDetail(Student input)
        {
            _student.InsertStudent(input);
            return Ok(input);
        }

        [HttpPut]
        [Route("updatestudentdetail")]
        public dynamic UpdateStudentDetail(int id, Student input)
        {
            var student = _student.UpdateStudent(id,input);
            return Ok(student);
        }

        [HttpDelete]
        [Route("deletestudentdetail")]
        public dynamic DeleteStudentDetail(int Id)
        {
            _student.DeleteStudent(Id);
            return Ok();
        }




    }
}
