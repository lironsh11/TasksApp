
using Assignment_2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Services
{
    public class TasksManager : ITasksManager
    {

        TasksContext1 db = new TasksContext1();

        //all tasks functions - get list, add new task, delete current task, and update current task
        public List<Tasks> GetAllTasks()
        {
            return db.Tasks.ToList();
        }

        public void AddTasks(Tasks task)
        {

            db.Tasks.Add(task);
        }


 
        public Tasks GetTasksById(int id)
        {
            return db.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTasks(Tasks Task)
        {
            db.Tasks.Update(Task);
        }

        public void DeleteTasks(Tasks Task)
        {
            db.Tasks.Remove(Task);
        }
        public void SaveChanges()
        {
            db.SaveChanges();

        }

    }
}
