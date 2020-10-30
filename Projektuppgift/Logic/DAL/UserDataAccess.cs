using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.DAL
{
    public class UserDataAccess
    {
        private const string path = @"DAL\User.json";
        private const string path2 = @"DAL\UserDic.json";

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

        public void CreateNewUser(string id, List<User>listOfUsers)
        {

            Dictionary<string, List<User>> test = new Dictionary<string, List<User>>();

            test.Add(id, listOfUsers);

            FileStream fileStream = File.OpenRead(path2);

            StreamReader streamReader = new StreamReader(fileStream);

            string Json = streamReader.ReadToEnd();

            test = JsonSerializer.Deserialize<Dictionary<string, List<User>>>(Json);
            streamReader.Close();



            Json = JsonSerializer.Serialize(test);

            fileStream = File.OpenWrite(path2);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(Json);
            streamWriter.Close();



        }


        public void CreatNewUserList(string username, string password)
        {


            List<User> users = new List<User>();
            FileStream fileStream = File.OpenRead(path);

            StreamReader streamReader = new StreamReader(fileStream);

            string Json = streamReader.ReadToEnd();

            users = JsonSerializer.Deserialize<List<User>>(Json);
            streamReader.Close();




            users.Add(new User { Username = username, Password = password });

            Json = JsonSerializer.Serialize(users);

            fileStream = File.OpenWrite(path);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(Json);
            streamWriter.Close();

        }


        //public void GetSpecificOrder(string key, List<Orders> listOfOrders)
        //{
        //    // hämtar ut en specifik order som användaren vill åt genom att leta efter den nyckeln som användaren har skickat in. 


        //    var dictonaryUser = new User();

        //    FileStream fileStream = File.OpenRead(path);
        //    StreamReader streamReader = new StreamReader(fileStream);

        //    string Json = streamReader.ReadToEnd();

        //    dictonaryUser. = JsonSerializer.Deserialize<Dictionary<string, List<Orders>>>(Json);
        //    streamReader.Close();

        //    if (dictonaryOrder.OrderDictionary.TryGetValue(key, out listOfOrders))
        //    {

        //        foreach (var item in dictonaryOrder.OrderDictionary[key])
        //        {

        //            item.ToString();

        //        }
        //    }




        //}
    }
}