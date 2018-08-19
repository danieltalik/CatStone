﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_final_capstone_v2.Models;

namespace c_final_capstone_v2.DAL
{
   public interface IUserDao
    {
        Staff Login(string username, string password);
        Staff GetUser(string username); //TODO: Add Methods for GetUser with USERNAME and USERNAME & PASSWORD
        bool AddStaff(Staff staff);
    }
}
