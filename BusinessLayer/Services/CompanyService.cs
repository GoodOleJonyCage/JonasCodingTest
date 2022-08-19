using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<CompanyInfo> GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public void DeleteCompany(int id)
        {
            _companyRepository.DeleteCompany(id);
        }

        public bool AddCompany(CompanyInfo company)
        {
            return _companyRepository.AddCompany(ConvertToCompany(company));
        }

        public bool UpdateCompany(CompanyInfo company)
        {
            return _companyRepository.UpdateCompany(ConvertToCompany(company));
        }

        public Company ConvertToCompany(CompanyInfo companyinfo)
        {
            Company company = new Company()
            {
                CompanyName = companyinfo.CompanyName,
                AddressLine1 = companyinfo.AddressLine1,
                AddressLine2 = companyinfo.AddressLine2,
                AddressLine3 = companyinfo.AddressLine3,
                PostalZipCode = companyinfo.PostalZipCode,
                PhoneNumber = companyinfo.PhoneNumber,
                FaxNumber = companyinfo.FaxNumber,
                EquipmentCompanyCode = companyinfo.EquipmentCompanyCode,
                Country = companyinfo.Country,
                LastModified = companyinfo.LastModified

            };
            return company;
        }
    }
}
