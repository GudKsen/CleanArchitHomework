using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Models
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlResource { get; set; }
    }
}
