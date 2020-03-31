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
                DateValidation = t.DateValidation
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
                DateValidation = t.DateValidation
            };
        }
    }
}