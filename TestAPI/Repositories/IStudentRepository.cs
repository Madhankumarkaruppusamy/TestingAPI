namespace Test.Repositories
{
    public interface IStudentRepository
    {
        public dynamic InsertStudent(Student details);
        public List<Student> ReadStudent();
        public dynamic UpdateStudent(int ID, Student details);
        public dynamic DeleteStudent(int ID);
    }
}
