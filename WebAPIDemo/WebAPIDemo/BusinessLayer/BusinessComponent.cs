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

        public ToDoModel AddWorkItem(ToDoModel workItem)
        {
           int WorkItemID = DataLayer.InsertWorkItem(workItem);
           return DataLayer.GetWorkList().FirstOrDefault(x => x.ID == WorkItemID); 
        }

        public IEnumerable<ToDoModel> UpdateWorkItem(int ID, ToDoModel workItem)
        {
            try
            {
                return DataLayer.UpdateWorkItem(ID, workItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ToDoModel> DeleteWorkItem(int ID)
        {
            try
            {
                return DataLayer.DeleteWorkItem(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}