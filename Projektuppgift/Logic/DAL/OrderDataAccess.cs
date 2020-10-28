using Logic.Entities;
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


        public List<Orders> GetAllOrders()
        {

            //Skickar tillbaka en lista av ALLA aktiva orders från en lista, skiter i att ta ut en nyckel för att det inte behövs då vi är ute efter alla. 
            //SKickar heller inte in något då det bara ska retunera allt. 

            string jsonString = File.ReadAllText(path);
            List<Orders> list = JsonSerializer.Deserialize<List<Orders>>(jsonString);

            return list;
        }


        public void CreateOrders(string key, List<Orders> listOfOrder)
        {
            //Skapar en ny order genom att ta in en key och en lista av en order och lägger till det i dictonariy i klassen order i mappen Entities.


            Orders dictonaryOrder = new Orders();
            dictonaryOrder.OrderDictionary.Add(key, listOfOrder);


            string Json = JsonSerializer.Serialize(dictonaryOrder);

            FileStream fs = File.OpenWrite(path);

            StreamWriter sw = new StreamWriter(fs);

            sw.Write(Json);

            sw.Close();

        }


        public void GetSpecificOrder(string key, List<Orders> listOfOrders)
        {
            // hämtar ut en specifik order som användaren vill åt genom att leta efter den nyckeln som användaren har skickat in. 


            var dictonaryOrder = new Orders();

            FileStream fileStream = File.OpenRead(path);
            StreamReader streamReader = new StreamReader(fileStream);

            string Json = streamReader.ReadToEnd();

            dictonaryOrder.OrderDictionary = JsonSerializer.Deserialize<Dictionary<string, List<Orders>>>(Json);
            streamReader.Close();

            if (dictonaryOrder.OrderDictionary.TryGetValue(key, out listOfOrders))
            {

                foreach (var item in dictonaryOrder.OrderDictionary[key])
                {

                    item.ToString();

                }
            }













        }









    }
}
