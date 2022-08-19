using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyInfo> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        bool AddCompany(CompanyInfo company);
        bool UpdateCompany(CompanyInfo company);
        void DeleteCompany(int id);
    }
}
