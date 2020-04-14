using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using d = DalToDo.Data;
using APIToDo.Models;

namespace APIToDo.Utils
{
    public static class Mappers
    {
        public static ToDo ToLocal(this d.ToDo t)
        {
            return new ToDo
            {
                Id = t.Id,
                Titre = t.Titre,
                Description = t.Description,
                IsDone = t.IsDone,
                DateValidation = t.DateValidation,
                UserId = t.UserId
            };
        }

        public static d.ToDo ToGlobal(this ToDo t)
        {
            return new d.ToDo
            {
                Id = t.Id,
                Titre = t.Titre,
                Description = t.Description,
                IsDone = t.IsDone,
                DateValidation = t.DateValidation,
                UserId = t.UserId
            };
        }
        public static User ToLocal(this d.User t)
        {
            return new User
            {
                Id = t.Id,
                LastName = t.LastName,
                FirstName = t.FirstName,
                Email = t.Email,
                Pwd = t.Pwd
            };
        }

        public static d.User ToGlobal(this User t)
        {
            return new d.User
            {
                Id = t.Id,
                LastName = t.LastName,
                FirstName = t.FirstName,
                Email = t.Email,
                Pwd = t.Pwd
            };
        }

        public static User RegisterInfoToUser(this RegisterInfo registerInfo)
        {
            return new User
            {
                LastName = registerInfo.LastName,
                FirstName = registerInfo.FirstName,
                Email = registerInfo.Email,
                Pwd = registerInfo.Pwd
            };
        }
    }
}