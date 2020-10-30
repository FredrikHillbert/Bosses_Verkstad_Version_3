using Logic.Entities;
using Logic.Interface;
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


        public void CreateNewMechanic(string id, List<Mechanic>listOfMechanic)
        {

            Dictionary<string, List <Mechanic>> mechanicInfo = new Dictionary<string, List<Mechanic>>();


            try
            {
                FileStream fileStream = File.OpenRead(path);

                StreamReader streamReader = new StreamReader(fileStream);

                string Json = streamReader.ReadToEnd();

                mechanicInfo = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(Json);
                streamReader.Close();
                mechanicInfo.Add(id, listOfMechanic);

                Json = JsonSerializer.Serialize(mechanicInfo);

                fileStream = File.OpenWrite(path);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();


            }

            catch (Exception)
            {


                mechanicInfo.Add(id, listOfMechanic);


                FileStream fileStream = File.Create(path);

                StreamReader streamReader = new StreamReader(fileStream);

                streamReader.Close();


                string Json = JsonSerializer.Serialize(mechanicInfo);

                fileStream = File.OpenWrite(path);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();




            }





        }







    }
}
