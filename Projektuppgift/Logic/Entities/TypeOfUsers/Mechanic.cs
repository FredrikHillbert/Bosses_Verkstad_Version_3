using Logic.Entities.AllTheComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logic.Entities
{
    public class Mechanic : User
    {
        public Mechanic()
        {
        }

        public Mechanic(string firstName, string lastName, string birthDay, string dateOfEmp, bool engine, bool tire, bool window, bool brakes, bool kaross)
        {
            FirstNameOfMechanic = firstName;
            LastNameOfMechanic = lastName;
            BirthdayOfMechanic = birthDay;
            DateOfEmploymentOfMechanic = dateOfEmp;
            Engine = engine;
            Tire = tire;
            Brakes = brakes;
            Kaross = kaross;
            Window = window;
        }


        public string FirstNameOfMechanic { get; set; }

        public string LastNameOfMechanic { get; set; }

        public string BirthdayOfMechanic { get; set; }

        public string DateOfEmploymentOfMechanic { get; set; }

        public bool Engine { get; set; }
        public bool Tire { get; set; }
        public bool Window { get; set; }
        public bool Brakes { get; set; }
        public bool Kaross { get; set; }


    }
}
