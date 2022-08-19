using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public EmployeeInfo GetEmployee(string employeeCode)
        {
            var result = _employeeRepository.GetEmployee(employeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }
        public bool SaveEmployee(EmployeeInfo employee)
        {
            return _employeeRepository.SaveEmployee(ConvertToEmployee(employee));
        }

        public Employee ConvertToEmployee(EmployeeInfo info)
        {
            return new Employee()
            {
                EmployeeCode = info.EmployeeCode,
                EmployeeName = info.EmployeeName,
                Occupation = info.Occupation,
                EmployeeStatus = info.EmployeeStatus,
                EmailAddress = info.EmailAddress,
                Phone = info.Phone,
            };
        }
    }
}
