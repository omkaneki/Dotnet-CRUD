using CrudOperation.Models;

namespace CrudOperation.Interface
{
    public interface IStudentService
    {
        public IEnumerable<StudentsDTO> GetAllStudents();

        public string InsertStudents(StudentsDTO students);
    }
}
