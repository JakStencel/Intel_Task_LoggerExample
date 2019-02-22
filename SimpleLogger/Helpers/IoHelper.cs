using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Helpers
{
    public interface IIoHelper
    {
        string GetDataToBeLogged(string message);
        string GetStringFromUser(string message);
        void PrintMessage(string message);
    }

    public class IoHelper : IIoHelper
    {
        public string GetDataToBeLogged(string message)
        {
            Console.WriteLine(message);
            var textToBeLogged = Console.ReadLine();

            while(string.IsNullOrEmpty(textToBeLogged))
            {
                Console.WriteLine("Don't leave it empty, please fill some data to be logged!");
                textToBeLogged = Console.ReadLine();
            }

            return textToBeLogged;
        }

        public string GetStringFromUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
