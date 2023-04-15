using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        public int Add(Role entity)
        {
            if (entity == null) return 0;
            using (var ctx = new TodoDBContext())
            {
                ctx.Roles.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Role rol = ctx.Roles.SingleOrDefault(x => x.Id == id);
                if (rol==null) return false;
                ctx.Roles.Remove(rol);
                ctx.SaveChanges();
                return true;
            }
        }

        public Role Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Role role = ctx.Roles.SingleOrDefault(r  => r.Id == id);
                if (role==null) return null;
                return role;
            }
        }

        public bool Update(Role entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Role role = ctx.Roles.SingleOrDefault(r =>r.Id == entity.Id);
                if (role==null) return false;
                role.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
