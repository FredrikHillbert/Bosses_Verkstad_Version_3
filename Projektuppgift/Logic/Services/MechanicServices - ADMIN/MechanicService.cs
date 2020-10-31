using Logic.DAL;
using Logic.Entities;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logic.Services.MechanicServices___ADMIN
{
    public class MechanicService : ImechanicLogin
    {
        private MechanicDataAccess _db;

        public MechanicService()
        {

            _db = new MechanicDataAccess();
        }


        public void CreateNewMechanic(string id, List<Mechanic> listOfMechanic)
        {


            _db.CreateNewMechanic(id, listOfMechanic);

            //för att fixa en lista

        }


        public bool CheckIfValid(string firstName, string lastName, string dateOfBirth, string dateOfEmp, string id)
        {
            if (firstName != String.Empty && lastName != String.Empty && dateOfBirth != String.Empty && dateOfEmp != String.Empty && id != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool ActivUser(string Id)
        {
            Dictionary<string, List<Mechanic>> DeklarerarDictionary = new Dictionary<string, List<Mechanic>>();

            FileStream fileStream = File.OpenRead(UserDataAccess.path2);
            StreamReader streamReader = new StreamReader(fileStream);

            string Json = streamReader.ReadToEnd();

            DeklarerarDictionary = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(Json);///------------------------Problem Med att ta bort fil andra gången!
            streamReader.Close();

            if (DeklarerarDictionary.ContainsKey(Id))//-------------------------Kollar efter användare finns
            {
                return true;

            }
            return false;
        }

        public void DeleteMechanic(string id)

        {
            Dictionary<string, List<Mechanic>> userInfo = new Dictionary<string, List<Mechanic>>();
            FileStream fileStream = File.OpenRead(UserDataAccess.path2);

            StreamReader streamReader = new StreamReader(fileStream);

            string Json = streamReader.ReadToEnd();

            userInfo = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(Json);
            streamReader.Close();

            if (userInfo.ContainsKey(id))//-------------------------Kollar efter användare finns
            {
                userInfo.Remove(id);

            }


            Json = JsonSerializer.Serialize(userInfo);

            fileStream = File.OpenWrite(UserDataAccess.path2);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine(Json);
            streamWriter.Close();

        }

    }
}