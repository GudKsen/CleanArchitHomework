using CleanArchitHomework.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Models
{
    public class TaskClass
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual string? Grade { get; set; }
        public virtual DateTime? Deadline { get; set; }
        public virtual IEnumerable<Resource>? Resources { get; set; }

        public TaskClass() { }

        public TaskClass(string namet, string description, string grade,  DateTime deadline, IEnumerable<Resource> resources)
        {
            Name = namet;
            Description = description;
            Deadline = deadline;
            Grade = grade;
            Resources = resources;
        }


        public override string ToString()
        {
            return $"ID: {ID}  Name: {Name}  Description: {Description}";
        }

        public override bool Equals(object t)
        {
            if (!(t is TaskClass task))
            {
                return false;
            }

            if (task.Name != Name)
            {
                return false;
            }
            else if (task.Description != Description)
            {
                return false;
            }
           
            else if (task.Deadline != Deadline)
            {
                return false;
            }
            return true;
        }



        public int CompareTo(TaskClass other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
