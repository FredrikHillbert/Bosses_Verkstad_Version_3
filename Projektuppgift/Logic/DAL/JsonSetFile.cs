using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logic.DAL
{
   public class JsonSetFile: JsonFile
    {
        public void SetJson()
        {
            SaveListAdmin(pathAdmin);
            SaveMechanicDictionary(pathMechanic);
            SaveListUser(pathUser);
            SaveVehicleList(pathVehicles);
            SaveOrderDictionary(pathOrder);
        }
        private void SaveMechanicDictionary(string path)
        {
            FileStream fileStream = File.OpenWrite(path);
            fileStream.SetLength(0);
            fileStream.Close();

            if (ActivClasses.mechanicDictionary.Count != 0)
            {
                string Json = JsonSerializer.Serialize(ActivClasses.mechanicDictionary);
                fileStream = File.OpenWrite(path);
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(Json);

                }
            }
            else
            {
                //ta bort json?
                File.Delete(path);

            }
        }

        private void SaveOrderDictionary(string path)
        {

            FileStream fileStream = File.OpenWrite(path);
            fileStream.SetLength(0);
            fileStream.Close();

            if (ActivClasses.orderDictionary.Count != 0)
            {
                string Json = JsonSerializer.Serialize(ActivClasses.orderDictionary);
                fileStream = File.OpenWrite(path);
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(Json);

                }
            }
            else
            {
                //ta bort json?
                File.Delete(path);

            }
        }
        private void SaveListAdmin(string path)
        {
            
                FileStream fileStream = File.OpenWrite(path);
                fileStream.SetLength(0);
                fileStream.Close();
                string Json = JsonSerializer.Serialize(ActivClasses.loginListAdmin);
                fileStream = File.OpenWrite(path);
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(Json);

            }


        }

        private void SaveListUser(string path)
        {
            FileStream fileStream = File.OpenWrite(path);
            fileStream.SetLength(0);
            fileStream.Close();

            if (ActivClasses.loginListUser.Count != 0)
            {
                string Json = JsonSerializer.Serialize(ActivClasses.loginListUser);
                fileStream = File.OpenWrite(path);
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(Json);

                }
            }
            else
            {
                //ta bort json?
                File.Delete(path);

            }

        }


        private void SaveVehicleList(string path)
        {

                FileStream fileStream = File.OpenWrite(path);
                fileStream.SetLength(0);
                fileStream.Close();
                string Json = JsonSerializer.Serialize(ActivClasses.ListOfVehicles);
                fileStream = File.OpenWrite(path);
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(Json);
              
            }

        }

    }
}

