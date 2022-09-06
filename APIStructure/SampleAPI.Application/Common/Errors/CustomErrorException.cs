using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Application.Common.Errors
{
    public class CustomErrorException : Exception, IServiceException
    {
        HttpStatusCode IServiceException.StatusCode => HttpStatusCode.NonAuthoritativeInformation;

        string IServiceException.ErrorMessage => "Custom Error";
    }
}
