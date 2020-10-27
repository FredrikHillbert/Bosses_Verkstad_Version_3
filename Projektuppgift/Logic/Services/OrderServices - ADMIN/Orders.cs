using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using Logic.Entities;
using System.Reflection;
using System.ComponentModel;
using Logic.Entities.AllTheComponents;
using Logic.DAL;

namespace Logic.Services.OrderServices
{
    public class Orders
    {
        public string OrderName { get; set; }
        public string DescriptionOfProblem { get; set; }
        public bool StatusOnOrder { get; set; }

        public string TypeOfVehicle { get; set; }

        private OrderDataAccess _db;



        public Orders()
        {

            _db = new OrderDataAccess();

        }

        public Orders(string desc, string orderName, string typeOfVehicle, bool status, string mechanic, bool whatIsBroke) 
        {

            
        }



        public void CreateOrder()
        {

            List<Orders> listOfNewOrder = new List<Orders>();
            var mechanic = new Mechanic();
            var comp = new Components();

            string description = DescriptionOfProblem;
            string ordername = OrderName;
            string typeOfVehicle = TypeOfVehicle;
            bool status = StatusOnOrder;
            string orderMechanic = mechanic.NameOfMechanic; // vet inte om den här funkar
            // har inte gjort att en mekaniker som inte har kompetens inte kan bli addad. 
            bool whatIsBroke = comp.WhatIsBroken();

            // Lägger till allt i en lista som sen skickas till databasen

            listOfNewOrder.Add(new Orders(description, ordername, typeOfVehicle, status, orderMechanic, whatIsBroke));


            // skickar iväg till databasen
            _db.CreateOrders(listOfNewOrder);


        }

        

        private static void CreateVehicleToOrder(Vehicles vehicles)
        {
            string regNumber = vehicles.RegNumber;
            string ModelName = vehicles.ModelName;
            int matare = vehicles.Matare;
            DateTime regDate = vehicles.RegDate;
            string fuel = vehicles.Fuel;


      


    }


        private static Car CreateCar()
        {
            Car newCar = new Car();

            CreateVehicleToOrder(newCar);

            string typeOfCar = newCar.TypeOfCar;
            bool haveTowBar = newCar.HaveTowBar;


            return newCar;

            

        }



    }
}
