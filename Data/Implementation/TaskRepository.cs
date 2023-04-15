using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Model.Task;

namespace Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        public int Add(Domain.Model.Task entity)
        {
            if (entity == null) return 0;
            using (var ctx = new TodoDBContext())
            {
                ctx.Tasks.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }
        public bool Delete(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Task tsk = ctx.Tasks.SingleOrDefault(t => t.Id == id);
                if (tsk==null) return false;
                ctx.Tasks.Remove(tsk);
                ctx.SaveChanges();
                return true;
            }
        }

        public Domain.Model.Task Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                Task task = ctx.Tasks.SingleOrDefault(t => t.Id==id);
                if (task==null) return null;
                return task;
            }
        }

        public bool Update(Domain.Model.Task entity)
        {
            using (var ctx = new TodoDBContext())
            {
                Task task = ctx.Tasks.SingleOrDefault(t => t.Id == entity.Id); //busca el objeto Task con el id correspondiente
                task.Nombre = entity.Nombre;
                task.Descripcion = entity.Descripcion;
                task.Status = entity.Status;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
