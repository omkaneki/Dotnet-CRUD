using CrudOperation.Interface;
using CrudOperation.Models;
using System.Data.SqlClient;

namespace CrudOperation.Services
{
    public class StudentService : IStudentService
    {
        public string Connect = "Data Source=LAPTOP-CR764SMB;Initial Catalog=Practise;Integrated Security=True";

        public IEnumerable<StudentsDTO> GetAllStudents()
        {
            SqlConnection Connection = new SqlConnection(Connect);
            Connection.Open();
            SqlCommand command = new SqlCommand("Select * From StudentTable", Connection);
            var StudentInfo = new List<StudentsDTO>();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    StudentsDTO student = new StudentsDTO
                    {
                        StudentId = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        City = reader.GetString(2),
                        IsActive = reader.GetBoolean(3),

                    };
                    StudentInfo.Add(student);
                }
            }
            return StudentInfo;

        }
        public string InsertStudents(StudentsDTO students)
        {
            SqlConnection Connection = new SqlConnection(Connect);
            Connection.Open();
            if (students != null)
            {

                int isActiveValue = students.IsActive ? 1 : 0;
                SqlCommand command = new SqlCommand($"Insert into StudentTable(SName,City,IsActive) values (@StudentName, @City, @IsActive)", Connection);
                //command.Parameters.AddWithValue("@StudId", students.StudentId);
                command.Parameters.AddWithValue("@StudentName", students.StudentName);
                command.Parameters.AddWithValue("@City", students.City);
                command.Parameters.AddWithValue("@IsActive", students.IsActive);
                command.ExecuteNonQuery();
            }
            return "Data inserted Successfully" + students;
        }
    }
}
