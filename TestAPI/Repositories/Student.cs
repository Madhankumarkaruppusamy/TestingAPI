using System.ComponentModel.DataAnnotations;

namespace Test.Repositories
{
    public class Student
    {
        [Key]
        public int? Id { get; set; }
        public string? StudentName { get; set; }
        public string? RollNumber { get; set; }
        public string? EmailId { get; set; }
        public long? PhoneNumber { get; set; }
        public string? City { get; set; }


    }
}
