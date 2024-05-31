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
            var student=_student.InsertStudent(input);
            return student;
        }

        [HttpPut]
        [Route("updatestudentdetail/{Id}")]
        public dynamic UpdateStudentDetail(int Id, Student input)
        {
            var student = _student.UpdateStudent(Id,input);
            return Ok(student);
        }

        [HttpDelete]
        [Route("deletestudentdetail/{Id}")]
        public dynamic DeleteStudentDetail(int Id)
        {
            _student.DeleteStudent(Id);
            return Ok();
        }




    }
}
