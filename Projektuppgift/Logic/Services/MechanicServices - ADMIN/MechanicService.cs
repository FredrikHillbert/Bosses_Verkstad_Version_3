using Logic.DAL;
using Logic.Entities;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
            if(firstName != String.Empty && lastName != String.Empty && dateOfBirth != String.Empty && dateOfEmp != String.Empty && id != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }

        }






    }
}
