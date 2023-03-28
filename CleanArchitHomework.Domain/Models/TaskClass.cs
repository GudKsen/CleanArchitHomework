using CleanArchitHomework.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitHomework.Domain.Models
{
    public class TaskClass
    {
        [Required]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }
        public virtual DateTime DatePublish {  get; set; }
        public virtual string Author { get; set; }
        public virtual string? Grade { get; set; }
        [Required(ErrorMessage = "Deadline must exist")]
        public virtual DateTime? Deadline { get; set; }
        public virtual IEnumerable<Resource>? Resources { get; set; }
        public virtual IEnumerable<Comment>? Comments { get; set; }

        public TaskClass() { }

        public TaskClass
            (
            string namet, 
            string description, 
            string grade,  
            string author,
            DateTime deadline, 
            IEnumerable<Resource> resources,
            IEnumerable<Comment> comments
            )
        {
            Name = namet;
            Description = description;
            Deadline = deadline;
            Grade = grade;
            Author = author;
            Resources = resources;
            Comments = comments;
            DatePublish = DateTime.Now;
        }


        public override string ToString()
        {
            return $"ID: {ID}  Name: {Name}  Description: {Description}";
        }

        //public override bool Equals(object t)
        //{
        //    //if (!(t is TaskClass task))
        //    //{
        //    //    return false;
        //    //}

        //    //if (task.Name != Name)
        //    //{
        //    //    return false;
        //    //}
        //    //else if (task.Description != Description)
        //    //{
        //    //    return false;
        //    //}
           
        //    //else if (task.Deadline != Deadline)
        //    //{
        //    //    return false;
        //    //}
        //    return true;
        //}



        public int CompareTo(TaskClass other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
