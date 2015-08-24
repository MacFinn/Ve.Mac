using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            IModeHandler service = new ModeHandler(new WordService(new FileWrapper()), new Validator(), new WordInverter());
            UserMode mode = GetMode();
            if (mode == UserMode.INSERT)
            {
                service.OrchestrateMode(mode, GetWord());  
            }
            else
            {
                service.OrchestrateMode(mode, "");  
            }
        }

        private static UserMode GetMode()
        {
            Console.WriteLine("Press 1 to store a word or press 2 to retrieve all stored inverted words.");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                return UserMode.INSERT;
            }
            else if (userInput == "2")
            {
                return UserMode.RETRIEVE;
            }
            else
            {
                Console.WriteLine("You did not enter a valid number, try again.");
                return UserMode.NONE;
            }
        }

        private static string GetWord()
        {
            Console.WriteLine("Enter the word you would like to store:");
            return Console.ReadLine();
        }
    }
}
