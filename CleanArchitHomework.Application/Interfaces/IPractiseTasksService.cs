using CleanArchitHomework.Application.ViewModels;
using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Application.Interfaces
{
    public interface IPractiseTasksService
    {
        public IEnumerable<PractiseTask> GetViewTasks();
        public void AddTask(PractiseTask task);
        public void DeleteByID(Guid id);
        public void DeleteByName(string name_delete);
        public PractiseTask SearchByID(Guid id);
        public PractiseTask SearchByName(string name_search);
        public bool UpdateTask(PractiseTask taskClass);
    }
}
