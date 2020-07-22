using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIDemo.Models;
using WebAPIDemo.ServiceLayer;

namespace WebAPIDemo.BusinessLayer
{
    public class BusinessComponent
    {

        public static List<ToDoModel> workList = new List<ToDoModel>();
        public BusinessComponent() {
        }
        public IEnumerable<ToDoModel> GetWorkItemList()
        {
            return DataLayer.GetWorkList();
        }

        public ToDoModel GetWorkItemByID(int ID)
        {
            return DataLayer.GetWorkList().FirstOrDefault(x => x.ID == ID);
        }

        public IEnumerable<ToDoModel> AddWorkItem(ToDoModel workItem)
        {
            workList.Add(workItem);
            return workList;
        }
    }
}