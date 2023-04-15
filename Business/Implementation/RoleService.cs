using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        public RoleService(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public int Add(Role rol)
        {
            if (rol.Id <= 0) return 0;
            if (string.IsNullOrEmpty(rol.Name)) return 0;
            return _roleRepo.Add(rol);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_roleRepo.Delete(id));
        }

        public Role Get(int id)
        {
            Role rol = _roleRepo.Get(id);
            return rol;
        }

        public bool Update(Role rol)
        {
            if (rol.Id <= 0) return false;
            if (string.IsNullOrEmpty(rol.Name)) return false;
            return _roleRepo.Update(rol);
        }
    }
}
