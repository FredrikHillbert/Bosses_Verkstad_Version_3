using Logic.Entities.Workshop;
using Logic.Services.OrderServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Logic.DAL
{
    public class OrderDataAccess
    {

        private const string path = @"DAL\Orders.json";


        public List<Orders> GetOrders()
        {

            string jsonString = File.ReadAllText(path);
            List<Orders> list = JsonSerializer.Deserialize<List<Orders>>(jsonString);

            return list;
        }


        public void CreateOrders(List<Orders> inputText)
        {

            FileStream fs = File.OpenWrite(path);

            StreamWriter sw = new StreamWriter(fs);

            sw.Write(inputText);

            sw.Close();

        }



    }
}
