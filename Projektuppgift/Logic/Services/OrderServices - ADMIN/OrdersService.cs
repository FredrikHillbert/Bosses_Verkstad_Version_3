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
    public class OrderService
    {
        private OrderDataAccess _db;
        public OrderService()
        {
            _db = new OrderDataAccess();
        }


        public List<Orders> GetAllOrder(List<Orders> listOfOrders)
        {

            listOfOrders = _db.GetAllOrders();

            return listOfOrders;

        }


        public void CreateOrder(string key, List<Orders> listOfOrder)
        {

            _db.CreateOrders(key, listOfOrder);
        }


        //public bool GetSpecificOrder(string key, List<Orders> listOfOrder)
        //{




        //    //return getOrder.Exists(getOrder => getOrder.OrderDictionary.Equals(listOfOrders) && getOrder.OrderKey.Equals(key));
        //}


    }
}
