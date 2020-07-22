﻿using System;
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
            return BC.GetWorkItemList();
        }

        // GET api/values/5
        public ToDoModel Get(int id)
        {
            return BC.GetWorkItemByID(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}