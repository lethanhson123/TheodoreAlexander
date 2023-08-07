using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TA_Web_2020_API.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}