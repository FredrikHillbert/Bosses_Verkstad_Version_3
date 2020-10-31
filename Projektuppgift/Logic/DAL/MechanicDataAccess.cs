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




        public void CreateNewMechanic(string id, List<Mechanic> listOfMechanic)
        {

            Dictionary<string, List<Mechanic>> mechanicInfo = new Dictionary<string, List<Mechanic>>();


            try
            {
                FileStream fileStream = File.OpenRead(UserDataAccess.path2);

                StreamReader streamReader = new StreamReader(fileStream);

                string Json = streamReader.ReadToEnd();

                mechanicInfo = JsonSerializer.Deserialize<Dictionary<string, List<Mechanic>>>(Json);
                streamReader.Close();
                mechanicInfo.Add(id, listOfMechanic);

                Json = JsonSerializer.Serialize(mechanicInfo);

                fileStream = File.OpenWrite(UserDataAccess.path2);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();


            }

            catch (Exception)
            {


                mechanicInfo.Add(id, listOfMechanic);


                FileStream fileStream = File.Create(UserDataAccess.path2);

                StreamReader streamReader = new StreamReader(fileStream);

                streamReader.Close();


                string Json = JsonSerializer.Serialize(mechanicInfo);

                fileStream = File.OpenWrite(UserDataAccess.path2);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine(Json);
                streamWriter.Close();


            }



        }
      






    }
}
