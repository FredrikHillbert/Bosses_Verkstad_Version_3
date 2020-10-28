using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.DAL
{
    public class UserDataAccess
    {
        private const string path = @"DAL\User.json";

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {

            string jsonString = File.ReadAllText(path);
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

            return users;
        }

        public void CreatNewUser(string username, string password)
        {
    
            List<User> users = new List<User>();

            users.Add(new User{Username = username, Password = password });

            string Json = JsonSerializer.Serialize(users);
           
            FileStream fileStream = File.OpenWrite(path);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(Json);
            streamWriter.Close();
     
        }

    }
}
