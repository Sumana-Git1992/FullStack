using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.BusinessLayer;
using WebAPIDemo.Models;


namespace WebAPIDemo.Controllers
{
    public class ToDoListController : ApiController
    {
        BusinessComponent BC = new BusinessComponent();

        // GET api/values
        public IEnumerable<ToDoModel> Get()
        {
            return BC.GetWorkItemList().ToList();
        }

        // GET api/values/5

        public ToDoModel Get(int id)
        {
            return BC.GetWorkItemByID(id);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]ToDoModel workItem)
        {
            var message= Request.CreateResponse(HttpStatusCode.Created, BC.AddWorkItem(workItem));
            return message;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]ToDoModel workItem)
        {
            HttpResponseMessage message;
            try
            {
                message = Request.CreateResponse(HttpStatusCode.OK, BC.UpdateWorkItem(id, workItem));
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return message;
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage message;
            try
            {
                message = Request.CreateResponse(HttpStatusCode.OK, BC.DeleteWorkItem(id));
            }
            catch (Exception ex)
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return message;
        }
    }
}
