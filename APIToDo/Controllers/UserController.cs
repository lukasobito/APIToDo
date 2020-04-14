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
    public class UserController : ApiController
    {
        [Route("api/Users")]
        public List<User> Get()
        {
            return UserService.Instance.GetAll();
        }

        [Route("api/User/{id:int}")]
        public User Get(int id)
        {
            return UserService.Instance.GetOne(id);
        }

        [Route("api/User")]
        public HttpResponseMessage Post(User u)
        {
            UserService.Instance.Create(u);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [Route("api/User")]
        public HttpResponseMessage Put(User u)
        {
            UserService.Instance.Update(u);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        //[Route("api/User/{id:int}")]
        //public HttpResponseMessage Delete(int id)
        //{
        //    UserService.Instance.Delete(id);
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
    }
}
