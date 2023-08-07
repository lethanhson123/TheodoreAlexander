using BL.CustomExceptions;
using BL.EntityService;
using DAL;
using DAL.EntityService;
using DAL.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BL.BusinessService
{
    public class GeneralBusinessService : IDisposable
    {
        private readonly CountryEntityService _countryServices;
        private readonly DAL.EntityService.DataContextServices _dataServices;
        private readonly DynamicTableEntityService _dynamicServices;
        private bool disposed = false;

        public GeneralBusinessService(CountryEntityService countryServices, DAL.EntityService.DataContextServices dataServices, DynamicTableEntityService dynamicServices)
        {
            _countryServices = countryServices;
            _dataServices = dataServices;
            _dynamicServices = dynamicServices;
        }
        public async Task<Guid?> GetCountryId(string ipAddress)
        {
            return await _dataServices.GetCountryId(ipAddress);
        }
        public async Task<bool?> IsSiteAccessAllowed(string ipAddress)
        {
            return await _dataServices.IsSiteAccessAllowed(ipAddress);
        }
        public LocationMaxMind GetLocationMaxMind(Guid? countryId)
        {
            try
            {
                var locationMaxMind = _countryServices.GetCountryById_Queryable(countryId).Select(o => new LocationMaxMind
                {
                    Country = o.ISO,
                    ContinentId = o.Continent_ID,
                    CountryId = o.ID,
                    CountryFullName = o.Name
                }).FirstOrDefault();
                return locationMaxMind;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsShowInStock(string country)
        {
            return _dynamicServices.IsShowInStock(country);
        }
        public IEnumerable<JObject> GenerateJObjectFromXmlFile(string serPath)
        {
            //load xml
            var doc = XDocument.Load(serPath);
            foreach (var node in doc.Root.Descendants())
            {
                dynamic obj = new JObject();
                foreach (var child in node.Descendants())
                {
                    obj[child.Name.LocalName] = child.Value;
                    yield return obj;
                }
            }
        }
        public JObject ConvertJsonStringToJson(string xmlPath)
        {
            var doc = XElement.Load(xmlPath);
            var cdata = doc.DescendantNodes().OfType<XCData>().ToList();
            foreach (var cd in cdata)
            {
                cd.Parent.Add(cd.Value);
                cd.Remove();
            }
            //XmlDocument doc = new XmlDocument();
            //doc.Load(xmlPath);
            //doc.RemoveChild(doc.FirstChild);
            //string json = JsonConvert.SerializeXmlNode(doc);
            string json = JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.Indented);
            return JObject.Parse(json);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _countryServices.Dispose();
                _dataServices.Dispose();
                _dynamicServices.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
