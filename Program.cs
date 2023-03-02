using System.Diagnostics;
using System.Xml.Linq;

namespace WebLinks
{
    internal class Program
    {
        public class Weblink
        {
            public string länknamn, beskrivning, URL;

            public void Print()
            {
                Console.WriteLine($"Angiven länk: {länknamn}");
                Console.WriteLine($"    Beskrivning av länk: {beskrivning}");
                Console.WriteLine($"    URL: {URL}");
            }
        }
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
                    LoadFile("Weblinks.txt");
                }
                else if (command == "open")
                {
                    Console.Write("Linkname: ");
                    string linkName = Console.ReadLine();
                    OpenLink(linkName);
                }
                else if (command == "print")
                {
                    PrintFile("Weblinks.txt");
                }
                else if (command == "add link")
                {
                    Console.Write("Add new Link by typing \"linkname,description,URL\": ");
                    string newLink = Console.ReadLine();
                    AddLink(newLink);
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
            string[] splittedLink = link.Split(',');
            Weblink newLink = new Weblink();
            newLink.länknamn = splittedLink[0];
            newLink.beskrivning = splittedLink[1];
            newLink.URL = splittedLink[2];

            File.AppendAllText("Weblinks.txt", link);

        }

        private static void PrintFile(string file)
        {
            
        }

        private static void OpenLink(string linkName)
        {
            /*
            foreach (Link link in linksArray) {
                if (string.Compare(linkName, link.linkName)) {
                    Process proc = new Process();
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = link.URL;
                    proc.Start();
                    proc.WaitForExit();
                }
            }
            */

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = linkName; //Hela länken
            proc.Start();
            proc.WaitForExit();

        }

        private static void LoadFile(string file)
        {
            string[] rader = File.ReadAllLines(file);
            Weblink[] Länkar = new Weblink[rader.Length];
            int a = 0;
            foreach (string r in rader)
            {
                string[] delar = r.Split (',');
                Länkar[a] = new Weblink()
                {

                };
                int j = 0;
                foreach (string del in delar) {
                    Console.WriteLine(delar[j]);
                    j++;
                }   
                a++;
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
                "quit  - quit the program",
                "add link  -  add a new link"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
        
    }
}