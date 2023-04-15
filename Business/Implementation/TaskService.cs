using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITaskRepository = Data.Contracts.ITaskRepository;

namespace Business.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public int Add(Domain.Model.Task tsk)
        {
            if (tsk.Id <= 0) return 0;
            if (string.IsNullOrEmpty(tsk.Nombre)) return 0;
            if (string.IsNullOrEmpty(tsk.Descripcion)) return 0;
            if (string.IsNullOrEmpty(tsk.Status)) return 0;
            return _taskRepo.Add(tsk);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_taskRepo.Delete(id));
        }

        public Domain.Model.Task Get(int id)
        {
            Domain.Model.Task tsk = _taskRepo.Get(id);
            return tsk;
        }

        public bool Update(Domain.Model.Task tsk)
        {
            if (tsk.Id <= 0) return false;
            if (string.IsNullOrEmpty(tsk.Nombre)) return false;
            if (string.IsNullOrEmpty(tsk.Descripcion)) return false;
            if (string.IsNullOrEmpty(tsk.Status)) return false;
            return _taskRepo.Update(tsk);
        }
    }
}
