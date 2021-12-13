using System;
using System.Threading.Tasks;

namespace TextParsingClient
{
    public class Program
    {
        private static ConsoleClient.InputMode _inputMode = ConsoleClient.InputMode.FILE; // default mode
        static async Task Main(string[] args)
        {

            if (validateInput(args))
            {
                Console.WriteLine(string.Format("Reading from {0}", _inputMode));
                ConsoleClient consoleClient = new ConsoleClient(_inputMode);
                await consoleClient.process();
            }
            else
                Console.WriteLine("Wrong argument. Expected values are F (file), C (console) and DB (database).");
        }

        /**
          *    Checks if passed arguments are correct
          */
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
            else inputCorrect = false;
            // ignoring second and all next arguments
            return inputCorrect;
        }

    }
}
