using Logic.DAL;
using Logic.Entities;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic.Services
{
    public class AdminService : ILogic
    {
        string
        firstName = String.Empty,
        lastName = String.Empty,
        username = String.Empty,
        password = String.Empty,
        orderDescription = String.Empty,
        typeOfVehicle = String.Empty,
        ModelName = String.Empty,
        Regnum = String.Empty,
        matare = String.Empty,
        regDate = String.Empty,
        specificQ1 = String.Empty,
        specificQ2 = String.Empty,
        typeOfFuel = String.Empty,
        assignedMechanic = String.Empty,
        mechanicID = String.Empty;


        DateTime birthDay,
                 dateOfEmp;
        bool
        engine = false,
        tire = false,
        brakes = false,
        kaross = false,
        window = false,
        statusActive = false,
        statusInActive = false;

        public void DeleteMechanic(string id)
        {
            ActivClasses.mechanicDictionary.Remove(id);
            int index = ActivClasses.loginListUser.FindIndex(x => x.UserID == id);
            if(index != -1)
            ActivClasses.loginListUser.RemoveAt(index);
        }
        public List<Mechanic> GetMechanic(string id)
        {
            foreach (var item in ActivClasses.mechanicDictionary[id])
            {
                firstName = item.FirstNameOfMechanic;
                lastName = item.LastNameOfMechanic;
                birthDay = item.BirthdayOfMechanic;
                dateOfEmp = item.DateOfEmploymentOfMechanic;
                engine = item.Engine;
                tire = item.Tire;
                brakes = item.Brakes;
                kaross = item.Kaross;
                window = item.Window;
            }
            List<Mechanic> DeklareraLista = new List<Mechanic>();
            DeklareraLista.Add(new Mechanic
            {
                FirstNameOfMechanic = firstName,
                LastNameOfMechanic = lastName,
                BirthdayOfMechanic = birthDay,
                DateOfEmploymentOfMechanic = dateOfEmp,
                Engine = engine,
                Tire = tire,
                Brakes = brakes,
                Kaross = kaross,
                Window = window,
            });
            return DeklareraLista;
        }
        public List<string> GetKey()
        {
            string savekey = "";
            List<string> DeklareraLista = new List<string>();

            Dictionary<string, List<Mechanic>>.KeyCollection keys = ActivClasses.mechanicDictionary.Keys;
            foreach (string key in keys)
            {
                savekey = key;
                foreach (var item in ActivClasses.mechanicDictionary[key])
                {
                    string add = ($"ID: {savekey}" +
                        $"\nName: {item.FirstNameOfMechanic} {item.LastNameOfMechanic}");
                    DeklareraLista.Add(add);
                }
            }
            return (DeklareraLista);
        }
        public List<string> GetOnlyKey()
        {
            string savekey = string.Empty;
            List<string> DeklareraLista = new List<string>();

            Dictionary<string, List<Mechanic>>.KeyCollection keys = ActivClasses.mechanicDictionary.Keys;
            foreach (string key in keys)
            {
                savekey = key;
                foreach (var item in ActivClasses.mechanicDictionary[key])
                {
                    DeklareraLista.Add(savekey);
                }
            }
            return (DeklareraLista);
        }
        public List<string> GetActivUser()
        {
            List<string> DeklareraLista = new List<string>();

            foreach (var item in ActivClasses.loginListUser)
            {
                string add = ($"ID: {item.UserID}" +
                    $"\nName: {item.Username}" +
                    $"\nPassword: {item.Password}");
                DeklareraLista.Add(add);
            }
            return (DeklareraLista);
        }
        public List<string> GetVehicles()
        {
            List<string> showVehicles = new List<string>();

            foreach (var item in ActivClasses.ListOfVehicles)
            {
                showVehicles.Add(item);
            }
            return showVehicles;
        }
        public void NewMechanic(string id, List<Mechanic> listOfMechanic)
        {
            ActivClasses.mechanicDictionary.Add(id, listOfMechanic);
        }

        public void NewUser(string username, string password, string id)
        {
            if (ActivClasses.mechanicDictionary.ContainsKey(id))//-------------------------Kollar efter användare finns
            {
                foreach (var item in ActivClasses.mechanicDictionary[id])
                {
                    item.Username = username;
                    item.Password = password;
                   
                }
            }
            ActivClasses.loginListUser.Add(new User { Username = username, Password = password, UserID = id });
        }
        public void DeletLogin(string id)
        {
            if (ActivClasses.mechanicDictionary.ContainsKey(id))//-------------------------Kollar efter användare finns
            {
                foreach (var item in ActivClasses.mechanicDictionary[id])
                {
                    item.Username = string.Empty;
                    item.Password = string.Empty;
                    
                }
                int index = ActivClasses.loginListUser.FindIndex(x => x.UserID == id);
                ActivClasses.loginListUser.RemoveAt(index);    
            }
        }

        public string MehanicID()
        {
            return mechanicID;
            
        }

        public List<string> GetMechanicForTheJob(string value)
        {
            List<string> listaAvKeys = GetOnlyKey();

            List<string> newListOfMechanics = new List<string>();

            for (int i = 0; i < listaAvKeys.Count; i++)
            {
                string key = listaAvKeys[i];
                foreach (var item in ActivClasses.mechanicDictionary[key])
                {
                    if (value == "Brakes" && item.Brakes == true && item.ActivOrdersMechanic.Count <= 1)
                    {
                        string Name = $"{item.UserID} {item.UserID} {item.FirstNameOfMechanic} {item.LastNameOfMechanic}";
                        string id = item.UserID;
                        mechanicID = id;
                        newListOfMechanics.Add(Name);
                        
                    }
                    else if (value == "Tires" && item.Tire == true && item.ActivOrdersMechanic.Count <= 1)
                    {
                        string Name = $"{item.UserID} {item.FirstNameOfMechanic} {item.LastNameOfMechanic}";
                        string id = item.UserID;
                        mechanicID = id;
                        newListOfMechanics.Add(Name);
                        
                    }
                    else if (value == "Engine" && item.Engine == true && item.ActivOrdersMechanic.Count <= 1)
                    {
                        string Name = $"{item.UserID} {item.FirstNameOfMechanic} {item.LastNameOfMechanic}";
                        string id = item.UserID;
                        mechanicID = id;
                        newListOfMechanics.Add(Name);
                      
                    }
                    else if (value == "Window" && item.Window == true && item.ActivOrdersMechanic.Count <= 1)
                    {
                        string Name = $"{item.UserID} {item.FirstNameOfMechanic} {item.LastNameOfMechanic}";
                        string id = item.UserID;
                        mechanicID = id;
                        newListOfMechanics.Add(Name);
                        
                    }
                    else if (value == "Kaross" && item.Kaross == true && item.ActivOrdersMechanic.Count <= 1)
                    {
                        string Name = $"{item.UserID} {item.FirstNameOfMechanic} {item.LastNameOfMechanic}";
                        string id = item.UserID;
                        mechanicID = id;
                        newListOfMechanics.Add(Name);
                        
                    }
                }
            }
            return newListOfMechanics;
        }

        public void NewOrder(string id, List<Orders> newOrder)
        {
            ActivClasses.orderDictionary.Add(id, newOrder);
        }
        public List<Orders> GetOrder(string id)
        {
            foreach (var item in ActivClasses.orderDictionary[id])
            {
                orderDescription = item.OrderDescription;
                typeOfVehicle = item.TypeOfVehicle;
                ModelName = item.ModelName;
                Regnum = item.RegNumber;
                matare = item.Matare;
                regDate = item.RegDate;
                specificQ1 = item.SpecificQuestionAboutVehicle1;
                specificQ2 = item.SpecificQuestionAboutVehicle2;
                engine = item.Engine;
                tire = item.Tire;
                brakes = item.Brakes;
                kaross = item.Kaross;
                window = item.BrokeWindow;
                typeOfFuel = item.Fuel;
                assignedMechanic = item.Mechanic;

            }
            List<Orders> changedOrder = new List<Orders>();
            changedOrder.Add(new Orders
            {
                OrderDescription = orderDescription,
                TypeOfVehicle = typeOfVehicle,
                ModelName = ModelName,
                RegNumber = Regnum,
                Matare = matare,
                RegDate = regDate,
                SpecificQuestionAboutVehicle1 = specificQ1,
                SpecificQuestionAboutVehicle2 = specificQ2,
                Engine = engine,
                Tire = tire,
                Brakes = brakes,
                Kaross = kaross,
                BrokeWindow = window,
                Fuel = typeOfFuel,
                Mechanic = assignedMechanic
            }) ;
            return changedOrder;
        }
        public List<string> GetOnlyOrdersKey()
        {
            string savekey = string.Empty;
            List<string> DeklareraLista = new List<string>();

            Dictionary<string, List<Orders>>.KeyCollection keys = ActivClasses.orderDictionary.Keys;
            foreach (string key in keys)
            {
                savekey = key;
                foreach (var item in ActivClasses.orderDictionary[key])
                {
                    DeklareraLista.Add(savekey);
                }
            }
            return (DeklareraLista);
        }
        public List<string> GetKeyForOrder()
        {
            string savekey = "";
            List<string> DeklareraLista = new List<string>();

            Dictionary<string, List<Orders>>.KeyCollection keys = ActivClasses.orderDictionary.Keys;
            foreach (string key in keys)
            {
                savekey = key;
                foreach (var item in ActivClasses.orderDictionary[key])
                {
                    string add = ($"ID: {savekey}" +
                        $"\nName: {item.OrderDescription} {item.TypeOfVehicle}");
                    DeklareraLista.Add(add);
                }
            }
            return (DeklareraLista);
        }
        public void DeleteOrder(string id)
        {

            List<string> listaAvKeys = GetOnlyKey();
            
            for (int i = 0; i < listaAvKeys.Count; i++)
            {
                int index = -1;
                string key = listaAvKeys[i];
                foreach (var item in ActivClasses.mechanicDictionary[key])
                {
                    index = item.ActivOrdersMechanic.FindIndex(x => x.ID == id);
                    
                    if(index != -1)
                    {
                        item.ActivOrdersMechanic.RemoveAt(index);
                    }
                }
                
            }
            ActivClasses.orderDictionary.Remove(id);
        }
        public void GiveMechanicOrder(string id, List<Orders> newOrder)
        {
           
         
                foreach (var item in ActivClasses.mechanicDictionary[id])
                {
                    
                   List<Orders> newOrder1 = item.ActivOrdersMechanic;
                     if (newOrder1.Count==1)
                         item.ActivOrdersMechanic = newOrder.Concat(newOrder1).ToList();
                     else
                         item.ActivOrdersMechanic = newOrder;
                    
                }
            
        }
        public List<string> GetfinishedOrder()
        {  
            List<string> Lista = new List<string>();
            foreach (var item in ActivClasses.AllFinishedOrder)
            {
                string add = ($"ID: {item.ID}" +
                    $"\n Beskrivning: {item.OrderDescription} {item.TypeOfVehicle}" +
                    $"\n Fordnon:{item.TypeOfVehicle} " +
                    $"\n Ansvarig:{item.Mechanic}");
                Lista.Add(add);
            }
            return (Lista);
        }


        public List<Orders> finishedOrder(string id)
        {
            List<Orders> DeklareraLista = new List<Orders>();
            string mechanic = null;
            foreach (var items in ActivClasses.orderDictionary[id])
            {

                string orderDescription = items.OrderDescription;
                bool whatIsBroken1 = items.Brakes;
                bool whatIsBroken2 = items.BrokeWindow;
                bool whatIsBroken3 = items.Engine;
                bool whatIsBroken4 = items.Kaross;
                bool whatIsBroken5 = items.Tire;
                string vehicle = items.TypeOfVehicle;
                mechanic = items.Mechanic;
                string modellName = items.ModelName;
                string regNumber = items.RegNumber;
                string matare = items.Matare;
                string regDate = items.RegDate;
                string typeOfFuel = items.Fuel;
                string specificQOne = items.SpecificQuestionAboutVehicle1;
                string specificQTwo = items.SpecificQuestionAboutVehicle2;
                string mechanicID = items.MechanicID;

                string ide = items.ID;

                DeklareraLista.Add(new Orders(orderDescription, whatIsBroken1, whatIsBroken2, whatIsBroken3, whatIsBroken4, whatIsBroken5, vehicle, mechanic, modellName, regNumber, matare, regDate
                   , typeOfFuel, specificQOne, specificQTwo, ide, mechanicID));

            }

            return DeklareraLista;
        }


        public void MoveFinishedOrder(List<Orders> finished, string id) 
        {
            string mechanicID = "";

            foreach (var item in finished)
            {
                mechanicID = item.MechanicID;
            }
      
            foreach (var item in ActivClasses.mechanicDictionary[mechanicID])
             {
              item.FinishedOrdersMechanic.AddRange(finished);
              ActivClasses.AllFinishedOrder.AddRange(finished);
              int index = item.ActivOrdersMechanic.FindIndex(x => x.ID == id);
              item.ActivOrdersMechanic.RemoveAt(index);
              }
             ActivClasses.orderDictionary.Remove(id);
        }
    }
}


