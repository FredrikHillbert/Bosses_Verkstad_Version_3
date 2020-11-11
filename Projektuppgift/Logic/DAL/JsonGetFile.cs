using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logic.DAL
{
    public class JsonGetFile : JsonFile
    {
        public void GetJson()
        {

           
            AdminJson(pathAdmin);
            VehiclesJson(pathVehicles);
            UserJson(pathUser);
            MecanichJson(pathMechanic);  
            OrderJson(pathOrder);

        }
        private void AdminJson(string path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                ActivClasses.loginListAdmin = JsonSerializer.Deserialize<List<User>>(jsonString);

            }
            else
            {
                FileStream fileStream = File.Create(path);
                using (var streamReader = new StreamReader(fileStream)) { }
                ActivClasses.loginListAdmin.Add(new User { Username = "Bosse", Password = "1", UserID = "Admin" });


            }

        }

        private void VehiclesJson(string path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                ActivClasses.ListOfVehicles = JsonSerializer.Deserialize<List<string>>(jsonString);

            }
            else
            {
                FileStream fileStream = File.Create(path);
                using (var streamReader = new StreamReader(fileStream)) { }
                ActivClasses.ListOfVehicles.AddRange(new List<String>() { "Bil", "Buss", "Lastbil", "Motorcykel" });

            }

        }



        private void UserJson(string path)
        {
            if (File.Exists(path))
            {

                    string jsonString = File.ReadAllText(path);
                    ActivClasses.loginListUser = JsonSerializer.Deserialize<List<User>>(jsonString);
                   throw new Exception("The file is Empty, (Program will work, pleas add a user and restart!)");
              
            }
            else
            {
                FileStream fileStream = File.Create(path);
                using (var streamReader = new StreamReader(fileStream)) { };
            }

        }

        private void MecanichJson(string path)
        {
            if (File.Exists(path))
            {
                    string jsonString = File.ReadAllText(path);
                    ActivClasses.mechanicDictionary = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(jsonString);
                    throw new Exception("The file is Empty, (Program will work, pleas add a Mechanic and restart!)");
            }
            else
            {
                FileStream fileStream = File.Create(path);
                using (var streamReader = new StreamReader(fileStream)) { }

            }
        }

        private void OrderJson(string path)
        {
            if (File.Exists(path))
            { 
                    string jsonString = File.ReadAllText(path);
                    ActivClasses.orderDictionary = JsonSerializer.Deserialize<Dictionary<string, List<Orders>>>(jsonString);
                    throw new Exception("The file is Empty, (Program will work, pleas add a Mechanic and restart!)");
            }
            else
            {
                FileStream fileStream = File.Create(path);
                using (var streamReader = new StreamReader(fileStream)) { }

            }





        }
    }
}
