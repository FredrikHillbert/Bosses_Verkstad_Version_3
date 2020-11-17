using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic.MyExceptions
{
    public class ErrorException : Exception
    {
        public ErrorException() : base() { }
        public ErrorException(string message) : base(message) { }
        public ErrorException(string message, Exception inner) : base(message, inner) { }
        protected ErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }

     

        public override string Message
        {
            get
            {
                return"Somthing wrong, you missing a folder!" +
                    "\n" +
                    @"Go to: C:\Bosses_Verkstad_Version_3\Projektuppgift\GUI\bin\Debug\netcoreapp3.1" +
                    "\nAnd and a folder with the name: DAL." +
                    "\n Now you ready to restart the program!";
            }

        }
     










    }

}

