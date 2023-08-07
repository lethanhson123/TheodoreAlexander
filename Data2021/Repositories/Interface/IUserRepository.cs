using System;
using System.Collections.Generic;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IUserRepository : IRepository<TA.Data2021.Models.User>
    {
        TA.Data2021.Models.User GetByID(string ID);
    }
}

