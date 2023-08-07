using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IHR_Recruitment_IntroduceRepository : IRepositoryERP<HR_Recruitment_Introduce>
    {        
        public HR_Recruitment_Introduce GetByPhone(string phone);        
        public List<HR_Recruitment_Introduce> GetBySearchStringToList(string searchString);
    }
}

