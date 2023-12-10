using CrudOperation.Interface;
using CrudOperation.Models;
using System.Data.SqlClient;
using System.Net.WebSockets;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace CrudOperation.Services
{
    public class EmployeeService : IEmployeeService
    {
        public string Connect = "Data Source=LAPTOP-CR764SMB;Initial Catalog=Practise;Integrated Security=True";
        public IEnumerable<Employee> GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(Connect))

            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM TodoItems", connection);
                var employees = new List<Employee>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2)
                    };
                    employees.Add(employee);
                }

                return employees;
            }
        }
        public Employee GetEmpById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(Connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"Select * from TodoItems where Id={Id}", connection);
                Employee employee = null;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee = new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2)
                    };

                }
                return employee;
            }
        }
        public string AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(Connect);
            connection.Open();
            if (employee != null)
            {
                SqlCommand command = new SqlCommand($"Insert into TodoItems (Name, Age) values('{employee.Name}',{employee.Age})", connection);

                command.ExecuteNonQuery();

            }
            return "Data inserted Successfully " + employee.Name;

        }
        public int DeleteEmployee(int Id)
        {
            SqlConnection connection = new SqlConnection(Connect);
            connection.Open();
            SqlCommand command = new SqlCommand($"Delete from TodoItems where Id={Id}", connection);
            command.ExecuteNonQuery();
            return Id;
        }
        public string UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(Connect);
            connection.Open();
            SqlCommand command = new SqlCommand($"UPDATE TodoItems Set Name='{employee.Name}',Age={employee.Age} WHERE Id={employee.Id}", connection);
            command.ExecuteNonQuery();
            return "Record Deleted Successfully";
        }

    }
    
}