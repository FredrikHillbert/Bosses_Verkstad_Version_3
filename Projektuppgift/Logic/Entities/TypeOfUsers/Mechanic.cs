using Logic.Entities.AllTheComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logic.Entities
{
    class Mechanic : User
    {
        public string NameOfMechanic { get; set; }

        public DateTime BirthdayOfMechanic { get; set; }

        public DateTime DateOfEmploymentOfMechanic { get; set; }

        public Mechanic()
        {
            IsAdmin = false;
        }

    }
}
