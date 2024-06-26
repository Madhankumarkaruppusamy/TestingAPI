﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public List<Student> ReadStudent()
        {
            try
            {

                IQueryable<Student> student = _db.Student;
                return student.ToList();
            }
            catch (Exception ) 
            {
                return null ;
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


        public dynamic UpdateStudent(int Id, Student details)
        {
            try
            {
                var result = _db.Student.FirstOrDefault(m => m.Id == Id);
                if (result == null)
                {
                    return 404; // Return 404 if student with given Id is not found
                }

                result.StudentName = details.StudentName;
                result.RollNumber = details.RollNumber;
                result.EmailId = details.EmailId;
                result.PhoneNumber = details.PhoneNumber;
                result.City = details.City;

                _db.Student.Update(result);
                _db.SaveChanges();

                return 200; // Return 200 OK on successful update
            }
            catch (Exception ex)
            {
                return ex; // Return 500 Internal Server Error for other exceptions
            }
        }

        public dynamic DeleteStudent(int Id)
        {
            try
            {
                var student = _db.Student.Find(Id);
                if (student == null)
                {
                    return null;
                }
                _db.Student.Remove(student);
                _db.SaveChanges();
                return 200;
            }
            catch (Exception ex) 
            { 
                return ex; 
            }
        }
    }
}
