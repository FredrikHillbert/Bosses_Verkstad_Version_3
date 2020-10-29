using GUI.Admin.Employer;
using GUI.Admin.Home;
using GUI.Admin.User;
using GUI.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Tools
{
   public class ClassTools
    {
        public static HomePageAdmin  homePageAdmin = new HomePageAdmin();
        public static LogginPage logginPage = new LogginPage();
        public static UserOptions userOptions = new UserOptions();
        public static  EmployerOptions employerOptions = new EmployerOptions();
        public static AddUser addUser = new AddUser();
        public static  ChangeUserAccount changeUserAccount = new ChangeUserAccount();

    }
}
