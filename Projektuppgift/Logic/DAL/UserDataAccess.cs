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
        public const string path2 = @"DAL\Mechanic.json";
        public const string path3 = @"DAL\MechanicLoggin.json";

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

        public void CreateNewUser(string username, string password, string id)
        {

            Dictionary<string, List<Mechanic>> userInfo = new Dictionary<string, List<Mechanic>>();

            List<Mechanic> DeklareraLista = new List<Mechanic>();

            try
            {
                FileStream fileStream = File.OpenRead(path2);

                StreamReader streamReader = new StreamReader(fileStream);

                string Json = streamReader.ReadToEnd();

                userInfo = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(Json);
                streamReader.Close();
                

                if (userInfo.ContainsKey(id))//-------------------------Kollar efter användare finns
                {
                    string firstName = "";
                    string lastName = "";
                    string birthDay = "";
                    string dateOfEmp = "";
                    bool engine = false;
                    bool tire = false;
                    bool brakes = false;
                    bool kaross = false;
                    bool window = false;
                    foreach (var item in userInfo[id])
                    {
                         firstName= item.FirstNameOfMechanic;
                        lastName =item.LastNameOfMechanic; 
                         birthDay= item.BirthdayOfMechanic;
                         dateOfEmp =item.DateOfEmploymentOfMechanic;
                         engine = item.Engine;
                         tire= item.Tire;
                          brakes =item.Brakes;
                       kaross = item.Kaross;
                      window= item.Window;
                    }
                    DeklareraLista.Add(new Mechanic{FirstNameOfMechanic= firstName, LastNameOfMechanic = lastName, BirthdayOfMechanic = birthDay,
                        DateOfEmploymentOfMechanic= dateOfEmp, Engine=engine, Tire = tire, Brakes = brakes, Kaross = kaross, Window = window,
                        Username = username, Password = password, UserID = id });

                    userInfo.Remove(id);
                    userInfo.Add(id, DeklareraLista);


                }
                

                Json = JsonSerializer.Serialize(userInfo);

                fileStream = File.OpenWrite(path2);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();


            }

            catch (Exception)
            {


             


                FileStream fileStream = File.Create(path3);

                StreamReader streamReader = new StreamReader(fileStream);

                streamReader.Close();


                string Json = JsonSerializer.Serialize(userInfo);

                fileStream = File.OpenWrite(path3);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();




            }





        }


        public void CreatNewUserList(string username, string password)
        {


            List<User> users = new List<User>();

            try
            {
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
            catch (Exception)
            {
                File.Create(path);

                users.Add(new User { Username = username, Password = password });


                FileStream fileStream = File.Create(path);

                StreamReader streamReader = new StreamReader(fileStream);

                streamReader.Close();


                string Json = JsonSerializer.Serialize(users);

                fileStream = File.OpenWrite(path);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();
            }
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
        //public bool ActivUser(string Id)
        //{
        //    Dictionary<string, List<string>> DeklarerarDictionary = new Dictionary<string, List<string>>();

        //    FileStream fileStream = File.OpenRead(path2);
        //    StreamReader streamReader = new StreamReader(fileStream);

        //    string Json = streamReader.ReadToEnd();

        //    DeklarerarDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(Json);
        //    streamReader.Close();

        //    if (DeklarerarDictionary.ContainsKey(Id))//-------------------------Kollar efter användare finns
        //    {
        //        return true;

        //    }
        //    return false;
        //}
    }
}