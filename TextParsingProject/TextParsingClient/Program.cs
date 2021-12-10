using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace TextParsingClient
{
public class Program
{
        private static ConsoleClient.InputMode _inputMode = ConsoleClient.InputMode.DATABASE; // default mode
        static async Task Main(string[] args)
        {

            if (validateInput(args))
            {
                ConsoleClient consoleClient = new ConsoleClient(_inputMode);
                consoleClient.process();
            }
            else
                Console.WriteLine("Wrong argument");
        }

        private static bool validateInput(string[] args)
        {
            bool inputCorrect = true;
            if (args.Length > 0)
            {
                switch (args[0].ToUpper())
                {
                    case "F": _inputMode = ConsoleClient.InputMode.FILE; break;
                    case "C": _inputMode = ConsoleClient.InputMode.CONSOLE; break;
                    case "DB": _inputMode = ConsoleClient.InputMode.DATABASE; break;
                    default:
                        inputCorrect = false;
                        break;
                }
            }
            // ignoring second and all next arguments
            return inputCorrect;
        }

    }
}
