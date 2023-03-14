using CleanArchitHomework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Application.ViewModels
{
    public class ViewTasksModel
    {
        public IEnumerable<TaskClass> Tasks { get; set; }
    }
}
