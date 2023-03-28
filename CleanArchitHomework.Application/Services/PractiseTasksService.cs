using CleanArchitHomework.Application.Interfaces;
using CleanArchitHomework.Application.ViewModels;
using CleanArchitHomework.Domain.Interfaces;
using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Application.Services
{
    public class PractiseTasksService : IPractiseTasksService
    {
        private IPractiseTaskRepository _tasksRepository;
        public PractiseTasksService(IPractiseTaskRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public IEnumerable<PractiseTask> GetViewTasks()
        {
            return _tasksRepository.GetTasks();
        }
        public void AddTask(PractiseTask taskClass)
        {
            _tasksRepository.AddTask(taskClass);
        }

        public void DeleteByID(Guid id)
        {
            _tasksRepository.DeleteByID(id);
        }

        public void DeleteByName(string name_delete)
        {
            _tasksRepository.DeleteByName(name_delete);
        }

        public PractiseTask SearchByID(Guid id)
        {
            PractiseTask task = _tasksRepository.SearchByID(id);
            return task;
        }

        public PractiseTask SearchByName(string name_search)
        {
            PractiseTask TaskClass = _tasksRepository.SearchByName(name_search);
            return TaskClass;
        }

        public bool UpdateTask(PractiseTask taskClass)
        {
            return _tasksRepository.UpdateTask(taskClass);
        }
    }
}
