using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Infrastructure.Data.Repository
{
    public class TaskRepository : ITasksRepository
    {
        private TaskDBContext _context;
        public TaskRepository(TaskDBContext context)
        {
            _context = context;
        }
        public IEnumerable<TaskClass> GetTasks()
        {
            return _context.Tasks;
        }

        public void AddTask(TaskClass task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteByID(Guid id)
        {
            TaskClass task = (TaskClass)(from c in _context.Tasks
                                     where (c.ID == id)
                                     select c).First();
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public void DeleteByName(string name_delete)
        {
            TaskClass task = (TaskClass)(from c in _context.Tasks
                                     where (c.Name == name_delete)
                                     select c).First();
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public TaskClass SearchByID(Guid id)
        {
            TaskClass task = (TaskClass)(from c in _context.Tasks
                                     where (c.ID == id)
                                     select c).First();
            return task;
        }

        public TaskClass SearchByName(string name_search)
        {
            TaskClass task = (TaskClass)(from c in _context.Tasks
                                     where (c.Name == name_search)
                                     select c).First();
            return task;
        }

        public bool UpdateTask(TaskClass task)
        {
            try
            {
                if (task != null)
                {
                    _context.Tasks.Update(task);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
