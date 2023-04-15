using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ITaskService

    {
        int Add(Domain.Model.Task tsk);
        //Read
        Domain.Model.Task Get(int id);
        //Update
        bool Update(Domain.Model.Task tsk);
        //Delete
        bool Delete(int tsk);
    }
}
