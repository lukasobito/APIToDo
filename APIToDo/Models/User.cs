﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIToDo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
    }
}