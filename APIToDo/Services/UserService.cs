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
    public class UserService : IRepository<User>
    {
        private static IRepository<User> instance;

        public static IRepository<User> Instance
        {
            get { return instance ?? (new UserService()); }
        }
        public void Create(User t)
        {
            UserRepository.Instance.Create(t.ToGlobal());
        }

        public void Delete(int id)
        {
            UserRepository.Instance.Delete(id);
        }

        public List<User> GetAll()
        {
            return UserRepository.Instance.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public User GetOne(int id)
        {
            return UserRepository.Instance.GetOne(id).ToLocal();
        }

        public void Update(User t)
        {
            UserRepository.Instance.Update(t.ToGlobal());
        }
    }
}