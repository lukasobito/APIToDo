using APIToDo.Models;
using APIToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIToDo.Controllers
{
    public class ToDoController : ApiController
    {
        [Route("api/ToDos")]
        public List<ToDo> Get()
        {
            return ToDoService.Instance.GetAll();
        } 

        [Route("api/ToDo/{id:int}")]
        public ToDo Get(int id)
        {
            return ToDoService.Instance.GetOne(id);
        }

        [HttpPost]
        [Route("api/ToDo")]
        public HttpResponseMessage Post(ToDo t)
        {
            ToDoService.Instance.Create(t);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/ToDo")]
        public HttpResponseMessage Put(ToDo t)
        {
            ToDoService.Instance.Update(t);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/ToDo/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            ToDoService.Instance.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
