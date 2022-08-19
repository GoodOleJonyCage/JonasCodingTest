using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;
using WebApi.Attributes;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET api/<controller>
        [LogApiRequest]
        [Route("api/company")]
        public IEnumerable<CompanyDto> GetAll()
        {
            var items = _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        [LogApiRequest]
        [Route("api/company/companyCode")]
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return  _mapper.Map<CompanyDto>(item);
        }

        //// POST api/<controller>
        [LogApiRequest]
        [Route("api/company")]
        [HttpPost]
        public async void Post(string CompanyName,
                                string AddressLine1,
                                string AddressLine2,
                                string AddressLine3,
                                string PostalZipCode,
                                string PhoneNumber,
                                string FaxNumber,
                                string EquipmentCompanyCode,
                                string Country)
        {
            //var company = _mapper.Map<CompanyDto>(value);
            _companyService.UpdateCompany(new CompanyInfo()
            {
                CompanyName = CompanyName,
                AddressLine1 =AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                PostalZipCode =PostalZipCode,
                PhoneNumber = PhoneNumber,
                FaxNumber = FaxNumber,
                EquipmentCompanyCode = EquipmentCompanyCode,
                Country = Country,
                LastModified = DateTime.Now
            });
        }

        // PUT api/<controller>/5
        [LogApiRequest]
        [HttpPut]
        public async void Put(int id, string CompanyName,
                                string AddressLine1,
                                string AddressLine2,
                                string AddressLine3,
                                string PostalZipCode,
                                string PhoneNumber,
                                string FaxNumber,
                                string EquipmentCompanyCode,
                                string Country)
        {
            _companyService.AddCompany(new CompanyInfo()
            {
                CompanyName = CompanyName,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AddressLine3 = AddressLine3,
                PostalZipCode =PostalZipCode,
                PhoneNumber = PhoneNumber,
                FaxNumber = FaxNumber,
                EquipmentCompanyCode = EquipmentCompanyCode,
                Country = Country,
                LastModified = DateTime.Now
            });
        }

        // DELETE api/<controller>/5
        [LogApiRequest]
        [HttpDelete]
        public async void Delete(int id)
        {
               _companyService.DeleteCompany(id );
        }
    }
}