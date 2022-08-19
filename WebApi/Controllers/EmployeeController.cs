using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Attributes;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        
        //private converter method
        public EmployeeDtocs ConvertFromEmployeeInfoToEmployeeDtocs(EmployeeInfo info) 
        {
            return new EmployeeDtocs()
            {
                EmployeeCode  = info.EmployeeCode,
                EmployeeName = info.EmployeeCode,
                CompanyName = info.EmployeeCode,
                OccupationName = info.EmployeeCode,
                EmployeeStatus = info.EmployeeCode,
                EmailAddress = info.EmployeeCode,
                PhoneNumber = info.EmployeeCode,
                LastModifiedDateTime = info.EmployeeCode,
            };
        }



        [LogApiRequest]
        [Route("api/employee/employeeCode")]
        public async Task<EmployeeDtocs> Get(string employeeCode)
        {
            var item =  _employeeService.GetEmployee(employeeCode);
            return _mapper.Map<EmployeeDtocs>(ConvertFromEmployeeInfoToEmployeeDtocs(item));
        }

        ////// POST api/<controller>
        [LogApiRequest]
        [Route("api/employee")]
        [HttpPut]
        public async void Put(    string EmployeeCode ,
                                  string EmployeeName,
                                  string CompanyName ,
                                  string OccupationName ,
                                  string EmployeeStatus ,
                                  string EmailAddress ,
                                  string PhoneNumber ,
                                  string LastModifiedDateTime 
                            )
        {

            _employeeService.SaveEmployee(new EmployeeInfo()
            {
                CompanyCode = CompanyName,
                EmployeeCode = EmployeeCode,
                EmployeeName = "",
                Occupation = OccupationName,
                EmployeeStatus = EmployeeStatus,
                EmailAddress = EmailAddress,
                Phone = PhoneNumber,
            });
        }
    }
}