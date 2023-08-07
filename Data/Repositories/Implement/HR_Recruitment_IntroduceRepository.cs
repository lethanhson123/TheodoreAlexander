using TA.Data.Models;
using TA.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace TA.Data.Repositories
{
    public class HR_Recruitment_IntroduceRepository : RepositoryERP<HR_Recruitment_Introduce>, IHR_Recruitment_IntroduceRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_Recruitment_IntroduceRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
       
        public override int Add(HR_Recruitment_Introduce model)
        {
            int result = AppGlobal.InitializationNumber;
            int check = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.FullName))
            {
                check = check + 1;
            }
            if (!string.IsNullOrEmpty(model.Phone))
            {
                check = check + 1;
            }
            if (check == 2)
            {
                Initialization(model);
                _context.Set<HR_Recruitment_Introduce>().Add(model);
                result = _context.SaveChanges();
            }
            return result;
        }       
        public List<HR_Recruitment_Introduce> GetBySearchStringToList(string searchString)
        {
            List<HR_Recruitment_Introduce> result = new List<HR_Recruitment_Introduce>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = _context.Set<HR_Recruitment_Introduce>().OrderByDescending(item => item.DateUpdated).ToList();
            }
            else
            {
                searchString = searchString.Trim();
                result = _context.Set<HR_Recruitment_Introduce>().Where(item => item.FullName.Contains(searchString) || item.Phone.Contains(searchString) || item.BankID.Contains(searchString) || item.BankName.Contains(searchString)).OrderByDescending(item => item.DateUpdated).ToList();
            }
            return result;
        }
        public HR_Recruitment_Introduce GetByID(int ID)
        {
            HR_Recruitment_Introduce result = new HR_Recruitment_Introduce();
            if (ID > 0)
            {
                result = _context.Set<HR_Recruitment_Introduce>().FirstOrDefault(model => model.ID == ID);
            }
            return result;
        }
        public HR_Recruitment_Introduce GetByPhone(string phone)
        {
            HR_Recruitment_Introduce result = new HR_Recruitment_Introduce();
            if (!string.IsNullOrEmpty(phone))
            {
                phone = phone.Trim();                
                result = _context.Set<HR_Recruitment_Introduce>().FirstOrDefault(model => model.Phone == phone);
            }
            return result;
        }        
    }
}

