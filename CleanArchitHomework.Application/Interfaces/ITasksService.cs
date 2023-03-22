using CleanArchitHomework.Application.ViewModels;
using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Application.Interfaces
{
    public interface ITasksService
    {
        public ViewTasksModel GetViewTasks();
        public void AddTask(TaskClass task);
        public void DeleteByID(Guid id);
        public void DeleteByName(string name_delete);
        public ViewSingleTaskModel SearchByID(Guid id);
        public ViewSingleTaskModel SearchByName(string name_search);
        public bool UpdateTask(TaskClass taskClass);
    }
}
