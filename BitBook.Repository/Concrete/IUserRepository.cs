﻿using BitBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.Concrete
{
    public interface IUserRepository
    {
        User UserLogin(string userName, string userPass);
    }
}
