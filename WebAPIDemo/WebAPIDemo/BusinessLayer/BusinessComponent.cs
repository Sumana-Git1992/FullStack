using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIDemo.Models;

namespace WebAPIDemo.BusinessLayer
{
    public class BusinessComponent
    {
        public static List<ToDoModel> workList = new List<ToDoModel>();
        public BusinessComponent() {
            workList.Add(new ToDoModel(1, "Brushing"));
            workList.Add(new ToDoModel(2, "Yoga"));
            workList.Add(new ToDoModel(3, "Breakfast"));
            workList.Add(new ToDoModel(4, "Cooking"));
            workList.Add(new ToDoModel(5, "Office"));
        }
        public IEnumerable<ToDoModel> GetWorkItemList()
        {
            return workList;
        }

        public ToDoModel GetWorkItemByID(int ID)
        {
            return workList.FirstOrDefault(x => x.ID == ID);
        }


    }
}