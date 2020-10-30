using Logic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface ImechanicLogin
    {
        bool CheckIfValid(string firstName, string lastName, string dateOfBirth, string dateOfEmp, string id);

        void CreateNewMechanic(string id, List<Mechanic> listOfMechanic);





    }
}
