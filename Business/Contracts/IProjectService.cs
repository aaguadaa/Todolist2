using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IProjectService

    {
        int Add(Project proj);
        //Read
        Project Get(int id);
        //Update
        bool Update(Project proj);
        //Delete
        bool Delete(int id);
    }
}
