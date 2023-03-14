using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Interfaces
{
    public interface ITasksRepository
    {
        IEnumerable<TaskClass> GetTasks();
        void AddTask(TaskClass task);
        void DeleteByID(Guid id);
        void DeleteByName(string name_delete);
        TaskClass SearchByID(Guid id);
        TaskClass SearchByName(string name_search);
    }
}
