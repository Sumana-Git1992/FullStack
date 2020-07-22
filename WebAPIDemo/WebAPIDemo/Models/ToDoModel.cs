using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class ToDoModel
    {
        public ToDoModel()
        {
        }
        public int ID { get; set; }
        public string WorkName { get; set; }

        public ToDoModel(int ID, string WorkName)
        {
            this.ID = ID;
            this.WorkName = WorkName;
        }
    }
}