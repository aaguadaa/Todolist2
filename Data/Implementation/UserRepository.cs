using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public int Add(User entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using(var ctx = new TodoDBContext())
            {
                ctx.Users.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
            
        }

        public bool Delete(int id)
        {
            using(var ctx = new TodoDBContext())
            {

                User us = ctx.Users.SingleOrDefault(u => u.Id == id);
                if (us == null) return false;

                ctx.Users.Remove(us);

                ctx.SaveChanges();
                return true;
            }
        }

        public User Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                User us = ctx.Users.SingleOrDefault(u => u.Id == id);
                if (us == null) return null;
                return us;
            }
        }

        public ICollection<Project> GetProjects(int idUser)
        {
            //throw new NotImplementedException();

            using (var ctx = new TodoDBContext())
            {
                User us = ctx.Users.SingleOrDefault(u => u.Id == idUser);
                if (us == null) return null;
                List<Project> projects = ctx.Users.Where(x => x.Id == idUser).SelectMany(x => x.Projects).ToList();
                return us.Projects;
            }
        }

        public bool RelateProject(Project project, int idUser)
        {
            using (var ctx = new TodoDBContext())
            {
                User us = ctx.Users.SingleOrDefault(u => u.Id == idUser);
                if (us == null) return false;


                us.Projects.Add(project);
                ctx.SaveChanges();
                return true;
            }
        }

        public bool Update(User entity)
        {
            using (var ctx = new TodoDBContext())
            {
                User u = ctx.Users.SingleOrDefault(x => x.Id == entity.Id);
                u.ModifiedDate = DateTime.Now;
                u.Name = entity.Name;
                u.Password = entity.Password;
                u.Email = entity.Email;
                u.UserName = entity.UserName;

                ctx.SaveChanges();
                return true;
            }
        }

    }
}
