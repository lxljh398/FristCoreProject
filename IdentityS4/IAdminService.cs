﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityS4
{
    public interface IAdminService
    {
        Task<Admin> GetByStr(string username, string pwd);//根据用户名和密码查找用户
    }
}
