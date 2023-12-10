using CrudOperation.Models;

namespace CrudOperation.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmpById(int Id);
        
        public string AddEmployee(Employee employee);
        
        public int DeleteEmployee(int id);
        public string  UpdateEmployee(Employee employee);
    }
}
