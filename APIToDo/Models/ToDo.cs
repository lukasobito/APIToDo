using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIToDo.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DateValidation { get; set; }
        public int UserId { get; set; }
    }
}