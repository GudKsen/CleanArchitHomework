using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Interfaces
{
    public interface IPractiseTaskRepository
    {
        IEnumerable<PractiseTask> GetTasks();
        void AddTask(PractiseTask task);
        void DeleteByID(Guid id);
        void DeleteByName(string name_delete);
        PractiseTask SearchByID(Guid id);
        PractiseTask SearchByName(string name_search);
        bool UpdateTask(PractiseTask task);
    }
}
