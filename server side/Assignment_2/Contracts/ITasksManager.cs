using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Contracts
{
    public interface ITasksManager
    {
        List<Tasks> GetAllTasks();

        void AddTasks(Tasks Task);

        Tasks GetTasksById(int IDd);

        void UpdateTasks(Tasks Task);

        void DeleteTasks(Tasks Task);

  
    }
}
