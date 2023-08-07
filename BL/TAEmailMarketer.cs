using DAL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace TA_Web_2020_API.Helper
{
    public interface TAEmailMarketerInterface
    {
        void AddNewUserMember(string email, string region);
        void AddRequestQuoteMember(string email, string region);
        void AddSubscriberMember(string email, string region);
    }
    public class TAEmailMarketer : EmailMarketerActionsTA, TAEmailMarketerInterface
    {
        public void AddNewUserMember(string email, string region)
        {
            if (ConstClass.TARegions.TAUS.Equals(region, StringComparison.OrdinalIgnoreCase))
            {
                AddNewUserMemberUS(email);
            }
            else
            {
                AddNewUserMemberINTL(email);
            }
        }

        public void AddRequestQuoteMember(string email, string region)
        {
            if (ConstClass.TARegions.TAUS.Equals(region, StringComparison.OrdinalIgnoreCase))
            {
                AddRequestQuoteMemberUS(email);
            }
            else
            {
                AddRequestQuoteMemberINTL(email);
            }
        }

        public void AddSubscriberMember(string email, string region)
        {
            if (ConstClass.TARegions.TAUS.Equals(region, StringComparison.OrdinalIgnoreCase))
            {
                AddSubscriberMemberUS(email);
            }
            else
            {
                AddSubscriberMemberINTL(email);
            }
        }
    }

    class EmmaAddMemberModel
    {
        public string email { get; set; }
        public List<string> group_ids { get; set; }
        public string signup_form_id { get; set; }
        public bool opt_in_confirmation { get; set; }

        public EmmaAddMemberModel(string email, List<string> groupIds, string signupFormId, bool optInConfirmation)
        {
            this.email = email;
            group_ids = groupIds;
            signup_form_id = signupFormId;
            opt_in_confirmation = optInConfirmation;
        }
    }

    public abstract class EmailMarketerActions
    {

        protected abstract void AddNewUserMemberINTL(string email);
        protected abstract void AddNewUserMemberUS(string email);
        protected abstract void AddRequestQuoteMemberINTL(string email);
        protected abstract void AddRequestQuoteMemberUS(string email);
        protected abstract void AddSubscriberMemberINTL(string email);
        protected abstract void AddSubscriberMemberUS(string email);
    }
    public class EmailMarketerActionsTA : EmailMarketerActionsEmma { }

    public class EmailMarketerActionsEmma : EmailMarketerActions
    {        
        private static string PublicKey = ConfigurationManager.AppSettings["PublicKey"];
        private static string PrivateKey = ConfigurationManager.AppSettings["PrivateKey"];
        private static string AccountID = ConfigurationManager.AppSettings["AccountID"];
        private static string SignupID = ConfigurationManager.AppSettings["SignupID"];
        private static string WebsiteRequestQuoteInternational = ConfigurationManager.AppSettings["WebsiteRequestQuoteInternational"];
        private static string WebsiteSubscriberInternational = ConfigurationManager.AppSettings["WebsiteSubscriberInternational"];
        private static string WebsiteUserInternational = ConfigurationManager.AppSettings["WebsiteUserInternational"];
        private static string WebsiteRequestQuoteUS = ConfigurationManager.AppSettings["WebsiteRequestQuoteUS"];
        private static string WebsiteSubscriberUS = ConfigurationManager.AppSettings["WebsiteSubscriberUS"];
        private static string WebsiteUserUS = ConfigurationManager.AppSettings["WebsiteUserUS"];

        protected override void AddSubscriberMemberUS(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteSubscriberUS }, SignupID, false);
                AddEmmaMember(model);
            }
        }
        protected override void AddSubscriberMemberINTL(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteSubscriberInternational }, SignupID, false);
                AddEmmaMember(model);
            }
        }

        protected override void AddNewUserMemberUS(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteUserUS }, SignupID, false);
                AddEmmaMember(model);
            }
        }
        protected override void AddNewUserMemberINTL(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteUserInternational }, SignupID, false);
                AddEmmaMember(model);
            }
        }


        protected override void AddRequestQuoteMemberUS(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteRequestQuoteUS }, SignupID, false);
                AddEmmaMember(model);
            }
        }

        protected override void AddRequestQuoteMemberINTL(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                EmmaAddMemberModel model = new EmmaAddMemberModel(email, new List<string> { WebsiteRequestQuoteInternational }, SignupID, false);
                AddEmmaMember(model);
            }
        }

        private void AddEmmaMember(EmmaAddMemberModel model)
        {           
            string content = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpClientHandler handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(PublicKey, PrivateKey);
            HttpClient request = new HttpClient(handler);
            System.Threading.Tasks.Task<HttpResponseMessage> result = request.PostAsync(String.Format("https://api.e2ma.net/{0}/members/signup", AccountID), stringContent);
        }
    }
}