using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CustomExceptions
{
    public class ServerException:Exception
    {
        public ServerException(string mess):base(mess)
        {

        }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string mess):base(mess)
        {

        }
    }
    public class BadRequestException: Exception
    {
        public BadRequestException(string mess):base(mess)
        {

        }
    }
}
