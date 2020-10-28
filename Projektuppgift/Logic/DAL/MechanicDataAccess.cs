using Logic.Entities;
using Logic.Services.OrderServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logic.DAL
{
    public class MechanicDataAccess
    {


        private const string path = @"DAL\Mechanic.json";


        //public List<Mechanic> GetMechanic()
        //{

        //    string jsonString = File.ReadAllText(path);
        //    List<Mechanic> list = JsonSerializer.Deserialize<List<Mechanic>>(jsonString);

        //    return list;
        //}

        public void CreateMechanic(string inputText)
        {

            FileStream fs = File.OpenWrite(path);

            StreamWriter sw = new StreamWriter(fs);

            sw.Write(inputText);

            sw.Close();

        }







    }
}
