using APIToDo.Models;
using APIToDo.Utils;
using DalToDo.Repository;
using DalToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIToDo.Services
{
    public class ToDoService : IRepository<ToDo>
    {
        private static IRepository<ToDo> instance;

        public static IRepository<ToDo> Instance
        {
            get { return instance ?? (new ToDoService()); }
        }

        public void Create(ToDo t)
        {
            ToDoRepository.Instance.Create(t.ToGlobal());
        }

        public void Delete(int id)
        {
            ToDoRepository.Instance.Delete(id);
        }

        public List<ToDo> GetAll()
        {
            return ToDoRepository.Instance.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public ToDo GetOne(int id)
        {
            return ToDoRepository.Instance.GetOne(id).ToLocal();
        }

        public void Update(ToDo t)
        {
            ToDoRepository.Instance.Update(t.ToGlobal());
        }
    }
}