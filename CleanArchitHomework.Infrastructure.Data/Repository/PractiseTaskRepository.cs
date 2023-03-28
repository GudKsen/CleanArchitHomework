using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Infrastructure.Data.Context;

namespace CleanArchitHomework.Infrastructure.Data.Repository
{
    public class PractiseTaskRepository : IPractiseTaskRepository
    {
        private TaskDBContext _context;
        public PractiseTaskRepository(TaskDBContext context)
        {
            _context = context;
        }
        public IEnumerable<PractiseTask> GetTasks()
        {
            return _context.TasksPractice;
        }

        public void AddTask(PractiseTask task)
        {
            _context.TasksPractice.Add(task);
            _context.SaveChanges();

        }

        public void DeleteByID(Guid id)
        {
            PractiseTask task = (PractiseTask)(from c in _context.TasksPractice
                                               where (c.ID == id)
                                         select c).First();
            if (task != null)
            {
                _context.TasksPractice.Remove(task);
                _context.SaveChanges();
            }
        }

        public void DeleteByName(string name_delete)
        {
            PractiseTask task = (PractiseTask)(from c in _context.TasksPractice
                                               where (c.Name == name_delete)
                                         select c).First();
            if (task != null)
            {
                _context.TasksPractice.Remove(task);
                _context.SaveChanges();
            }
        }

        public PractiseTask SearchByID(Guid id)
        {
            PractiseTask task = (PractiseTask)(from c in _context.TasksPractice
                                               where (c.ID == id)
                                         select c).First();
            return task;
        }

        public PractiseTask SearchByName(string name_search)
        {
            PractiseTask task = (PractiseTask)(from c in _context.TasksPractice
                                               where (c.Name == name_search)
                                         select c).First();
            return task;
        }

        public bool UpdateTask(PractiseTask task)
        {
            try
            {
                if (task != null)
                {
                    _context.TasksPractice.Update(task);
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
