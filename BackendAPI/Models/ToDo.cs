using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendAPI.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Status { get; set; }
        public string Category { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
    }
}