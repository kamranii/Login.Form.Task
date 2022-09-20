using System;
using System.Collections.Generic;

namespace Login.Form
{
    public class Database
    {
        public static List<User> users { get; set; }
        static Database()
        {
            users = new List<User>();
        }
    }
}

