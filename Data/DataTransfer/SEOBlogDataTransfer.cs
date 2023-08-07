using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class SEOBlogDataTransfer : TA.Data.Models.SEOBlog
    {
        public int Count { get; set; }
        public int RowBegin { get; set; }
        public int RowEnd { get; set; }
    }
}
