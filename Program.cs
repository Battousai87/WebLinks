using System.Xml.Linq;

namespace WebLinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintWelcome();
            string command;
            do
            {
                Console.Write(": ");
                command = Console.ReadLine();
                if (command == "quit")
                {
                    Console.WriteLine("Good bye!");
                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    LoadFile("WebLinks.txt");
                }
                else if (command == "open")
                {
                    OpenLink("WebLinks.txt");
                }
                else if (command == "print")
                {
                    PrintFile("Weblinks.txt");
                }
                else if (command == "add link")
                {
                    AddLink("");
                }
                else if (command == "save standard file")
                {
                    SaveStandardFile();
                }
                else if (command == "save to file")
                {
                    SaveToFile();
                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");
                }
            } while (command != "quit");
        }

        private static void SaveToFile()
        {
            
        }

        private static void SaveStandardFile()
        {
            
        }

        private static void AddLink(string link)
        {
            
        }

        private static void PrintFile(string file)
        {
            
        }

        private static void OpenLink(string file)
        {
            
        }

        private static void LoadFile(string file)
        {
            string[] rader = File.ReadAllLines(file);
            foreach (string r in rader)
            {

            }
        }

        private static void NotYetImplemented(string command)
        {
            Console.WriteLine($"Sorry: '{command}' is not yet implemented");
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Hello and welcome to the ... program ...");
            Console.WriteLine("that does ... something.");
            Console.WriteLine("Write 'help' for help!");
        }

        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
        
    }
}