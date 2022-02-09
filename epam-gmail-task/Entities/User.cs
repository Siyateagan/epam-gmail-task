﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_gmail_task.Entities
{
    public class User
    {
        public readonly string email;
        public readonly string password;

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
