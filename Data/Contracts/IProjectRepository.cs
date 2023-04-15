using Domain.Model;

namespace Data.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        bool RelateTask(Domain.Model.Task newTask);
    }
}