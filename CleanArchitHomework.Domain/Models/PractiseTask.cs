using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Models
{
    public class PractiseTask : TaskClass
    {
        public string Instructions { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; }
        public override string Grade { get; set; }
    }
}
