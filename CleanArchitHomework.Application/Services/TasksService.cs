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
    public class TasksService : ITasksService
    {
        private ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }
        public ViewTasksModel GetViewTasks()
        {
            return new ViewTasksModel
            {
                Tasks = _tasksRepository.GetTasks()
            };
        }
        public void AddTask(TaskClass taskClass)
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

        public ViewSingleTaskModel SearchByID(Guid id)
        {
            TaskClass task = _tasksRepository.SearchByID(id);
            return new ViewSingleTaskModel
            {
                taskClass = task,
            };
        }

        public ViewSingleTaskModel SearchByName(string name_search)
        {
            TaskClass TaskClass = _tasksRepository.SearchByName(name_search);
            return new ViewSingleTaskModel
            { 
                taskClass = TaskClass
            };
        }
    }
}


