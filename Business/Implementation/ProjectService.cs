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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }
        public int Add(Project proje)
        {
            if (proje.Id <= 0) return 0;
            if (string.IsNullOrEmpty(proje.Name)) return 0;
            if (string.IsNullOrEmpty(proje.Description)) return 0;
            return _projectRepo.Add(proje);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_projectRepo.Delete(id));
        }

        public Project Get(int id)
        {
            Project proj = _projectRepo.Get(id);
            return proj;
        }



        public bool Update(Project proj)
        {
            if (proj.Id <= 0) return false;
            if (string.IsNullOrEmpty(proj.Name)) return false;
            if (string.IsNullOrEmpty(proj.Description)) return false;
            return _projectRepo.Update(proj);
        }

        public bool RelateTask(Domain.Model.Task newTask)
        {
            throw new NotImplementedException();
        }
    }
}
