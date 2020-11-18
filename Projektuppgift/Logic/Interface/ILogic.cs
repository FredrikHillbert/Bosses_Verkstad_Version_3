using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
  public interface ILogic
    {

       
      
        //bool ValidLogin(string username, string password, string password2, string id);
        void DeletLogin(string id);

        // User Service -----

        void NewUser(string username, string password, string id);
         List<string> GetKey();
        List<string> GetActivUser();

        //Mechanic Service -----
        //bool ValidMechanic(string firstName, string lastName, string dateOfBirth, string dateOfEmp, string id);
        void NewMechanic(string id, List<Mechanic> listOfMechanic);
        List<Mechanic> GetMechanic(string id);
        void DeleteMechanic(string id);

        //Order Service ------
        //bool ValidOrder(string orderDescription, string vehicle, string mechanic,
        //                       string modellName, string regNumber, string matare, string regDate, string typeOfFuel, string specificQOne, string specificQTwo, string id);
        public List<string> GetVehicles();
        List<string> GetMechanicForTheJob(string value);

        void NewOrder(string id, List<Orders> newOrder);

        List<Orders> GetOrder(string id);

        List<string>GetKeyForOrder();
        void GiveMechanicOrder(string valueOfMechanic, List<Orders> newOrder);

        List<string> GetfinishedOrder();

        void DeleteOrder(string id);
        List<Orders> finishedOrder(string id);
        void MoveFinishedOrder(List<Orders> finished, string id);
       string MehanicID();
    }
}
