using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Models
{
    public class TheoryTask : TaskClass
    {
        public override IEnumerable<Resource> Resources { get; set; }
    }
}
