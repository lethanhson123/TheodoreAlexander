using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class PaginationModel
    {
        [Required]
        public int PageSize { get; set; }
        [Required]
        public int PageNum { get; set; }
    }
    public class PageResult<T>
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public bool PreviousPage { get; set; }
        public int PageSize { get; set; }
        public bool NextPage { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CountryFullName { get; set; }
        public string RequestIpAddress { get; set; }
        public string ResponseIpAddress { get; set; }
    }
}
