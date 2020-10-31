using Logic.DAL;
using Logic.Entities;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic.Services
{
    public class LoginService: IuserLogin
    {
        private UserDataAccess _db;

        public LoginService()
        {

            _db = new UserDataAccess();
        }

        public bool Login(string username, string password)
        {
            List<User> users = _db.GetUsers();
     
            return users.Exists(user => user.Username.Equals(username) && user.Password.Equals(password));
        }

        
        public void CreateNewUser(string username, string password, string id)
        {

            List<User> newUser = new List<User>();
           
         //   _db.CreateNewUser(id, newUser );

            //för att fixa en lista
            _db.CreatNewUserList(username, password);
        }
        public bool CheckIfLoginIsValid(string username, string password, string password2, string id)
        {

            if (Regex.IsMatch(username, @"^([\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$") && password == password2 && id != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
