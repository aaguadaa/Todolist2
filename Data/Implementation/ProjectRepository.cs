using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        public int Add(Project entity)
        {
            if (entity == null) return 0;
            using (var ctx = new TodoDBContext())
            {
                ctx.Projects.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }
        public bool Delete(int id)
        {
            using (var ctx = new TodoDBContext())
            {

                Project proj = ctx.Projects.SingleOrDefault(p => p.Id == id);
                if (proj == null) return false;

                ctx.Projects.Remove(proj);

                ctx.SaveChanges();
                return true;
            }
        }

        public Project Get(int id)
        {
           using (var ctx = new TodoDBContext())
            {
                Project proj = ctx.Projects.SingleOrDefault(p => p.Id == id);
                if (proj == null) return null;
                return proj;
            }
        }

        public bool RelateTask(Domain.Model.Task newTask)
        {
            throw new NotImplementedException();
        }
        public bool Update(Project entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Project proj = ctx.Projects.SingleOrDefault(x => x.Id == entity.Id);
                proj.Name = entity.Name;
                proj.Description = entity.Description;

                ctx.SaveChanges();
                return true;
            }
        }
    }
}
