using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
  public  interface IuserLogin
    {
        bool Login(string username, string password);
        void CreatNewUser(string username, string password);
    }
}
