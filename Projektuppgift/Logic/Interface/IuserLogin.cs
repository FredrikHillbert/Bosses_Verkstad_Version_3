using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
  public  interface IuserLogin
    {
        bool Login(string username, string password);
        void CreateNewUser(string username, string password, string id);
        bool CheckIfLoginIsValid(string username, string password, string password2, string id);
     


    }
}
