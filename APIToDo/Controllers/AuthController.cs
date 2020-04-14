using APIToDo.Models;
using APIToDo.Services;
using APIToDo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Tools.Cryptography;

namespace APIToDo.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/auth/register")]
        [HttpPost]
        public HttpResponseMessage Register(RegisterInfo registerInfo)
        {
            if (ModelState.IsValid)
            {
                if (!(UserService.Instance.GetAll().Select(x => x.Email).Contains(registerInfo.Email)))
                {
                    RSAEncryption encryption = new RSAEncryption();
                    registerInfo.Pwd = encryption.Decrypt(Encoding.ASCII.GetBytes(registerInfo.Pwd));
                    UserService.Instance.Create(registerInfo.RegisterInfoToUser());
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        //[Route("api/auth/register")]
        //[HttpPost]
        //public HttpResponseMessage Login(LoginInfo logininfo)
        //{
        //    if(!(loginForm is null) && ModelState.IsValid)
        //    {
        //        try
        //        {
        //            User user = 
        //        }
        //    }
        //}
    }
}
