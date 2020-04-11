using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut6.Services
{
    public interface IDbService
    {
        bool CheckIndex(string index);
    }
}
