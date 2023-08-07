using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_Recruitment_CareerRepository : IRepositoryERP<HR_Recruitment_Career>
    {        
        public List<HR_Recruitment_Career> GetByRecommendPhoneToList(string recommendPhone);
        public List<HR_Recruitment_Career> GetBySearchStringToList(string searchString);
        public List<HR_Recruitment_Career> GetByRecommendPhoneAndSearchStringToList(string recommendPhone, string searchString);
    }
}

