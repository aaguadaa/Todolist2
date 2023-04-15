using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRoleRepository
    {
        bool RelateUserWithRole(string userId, string roleId);
        bool IsUserInRole(string userId, string roleId);
    }
}
