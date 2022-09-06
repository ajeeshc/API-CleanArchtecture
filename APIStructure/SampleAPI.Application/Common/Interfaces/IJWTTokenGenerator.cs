using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Application.Common.Interfaces
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(Guid userid,string firstname,string lastname);
    }
}
