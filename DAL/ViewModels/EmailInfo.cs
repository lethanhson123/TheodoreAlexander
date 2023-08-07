using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class EmailInfo
    {
        [Required(ErrorMessage = "Invalid Name")]
        [MaxLength(254, ErrorMessage = "Name cannot be longer than 254 characters.")]
        public string PersonName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(254, ErrorMessage = "The Email address cannot be longer than 254 characters.")]
        public string PersonEmail { get; set; }
    }
    public class RequestSendEmailItemObj 
    {
        public string ItemId { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public bool IsSendCopy { get; set; } = false;
        public string Message { get; set; }
    }
}
