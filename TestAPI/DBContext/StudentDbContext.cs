using Microsoft.EntityFrameworkCore;
using Test.Repositories;

namespace Test.DBContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        #region Table
        public  DbSet<Student> Student { get; set; }

        #endregion Table
    }
}
