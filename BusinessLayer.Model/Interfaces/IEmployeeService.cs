using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeInfo GetEmployee(string employeeCode);
        bool SaveEmployee(EmployeeInfo employee);
    }
}
