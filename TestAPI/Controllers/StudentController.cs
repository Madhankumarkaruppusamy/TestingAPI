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
        [Route("GetStudentDetail")]
        public dynamic GetStudentDetail()
        {
            var student= _student.ReadStudent();
            return student();
        }

        [HttpPost]
        [Route("AddStudentDetail")]
        public dynamic AddStudentDetail(Student input)
        {
            _student.InsertStudent(input);
            return Ok(input);
        }

        [HttpPut]
        [Route("UpdateStudentDetail")]
        public dynamic UpdateStudentDetail(int id, Student input)
        {
            _student.UpdateStudent(id,input);
            return Ok(input);
        }

        [HttpDelete]
        [Route("DeleteStudentDetail")]
        public dynamic DeleteStudentDetail(int Id)
        {
            _student.DeleteStudent(Id);
            return Ok();
        }




    }
}
