﻿using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;
using static WebLinks.Program;

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
                    
                    Console.WriteLine("File name(leave empty for Weblinks.txt: ");
                    string file = Console.ReadLine();
                    if (file=="")
                    {
                        LoadFile("Weblinks");
                    }
                    else
                    { 
                        LoadFile(file);
                    }
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
                    string addLink, addDescription, addURL ;
                    
                    Console.WriteLine("Add a linkname: ");
                    addLink = Console.ReadLine();
                    Console.WriteLine("Add a description: ");
                    addDescription = Console.ReadLine();
                    Console.WriteLine("Add a URL: ");
                    addURL = Console.ReadLine();
                    
                    AddLink(addLink, addDescription, addURL);
                    
                    //Console.Write("Add new Link by typing \"linkname,description,URL\": ");
                    //string newLink = Console.ReadLine();
                    //AddLink(newLink);
                }
                else if (command == "zadd link")
                {
                    AddLinkWithZenity();
                }
                else if (command == "save standard file")
                {   
                    SaveStandardFile();
                }
                else if (command == "save to file")
                {
                    Console.Write("New file name: ");
                    string newFileName = Console.ReadLine();
                    SaveToFile(newFileName);
                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");
                }
            } while (command != "quit");
        }

        private static void SaveToFile(string newFileName)
        {
            string filePath = $"..\\..\\..\\{newFileName}.txt";
            File.Copy("..\\..\\..\\Weblinks.txt", filePath);
        }

        private static void SaveStandardFile()
        {
            
        }
        private static void AddLink(string addLink, string addDescription, string addURL)
        {   
            Weblink newLink = new Weblink();
            newLink.länknamn = addLink;
            newLink.beskrivning = addDescription;
            newLink.URL = addURL;
            File.AppendAllText("..\\..\\..\\Weblinks.txt", "\n");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addLink},");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addDescription},");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addURL}" );

            /*string[] splittedLink = link.Split(',');
            Weblink newLink = new Weblink();
            newLink.länknamn = splittedLink[0];
            newLink.beskrivning = splittedLink[1];
            newLink.URL = splittedLink[2];

            File.AppendAllText("..\\..\\..\\Weblinks.txt", link);
            */
        }

        private static void AddLinkWithZenity()
        {
            using (Process process = new Process())
            {
                string fullPathProgram = @"..\..\..\zenity.exe";
                string zenityArgs = $"--forms --add-entry=\"Link name\" \\ --add-entry=\"Description\" \\ --add-entry=\"URL\"";
                process.StartInfo.FileName = fullPathProgram;
                process.StartInfo.Arguments = zenityArgs;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
            }
            /*
            Weblink newLink = new Weblink();

            newLink.länknamn = addLink;
            newLink.beskrivning = addDescription;
            newLink.URL = addURL;
            File.AppendAllText("..\\..\\..\\Weblinks.txt", "\n");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addLink},");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addDescription},");
            File.AppendAllText("..\\..\\..\\Weblinks.txt", $"{addURL}");
            */
        }

        private static void PrintFile(string file)
        {
            
        }

        private static void OpenLink(string linkName)
        {
            string[] rows = File.ReadAllLines("..\\..\\..\\Weblinks.txt");
            Weblink[] links = new Weblink[rows.Length];

            for (int i = 0; i < rows.Length; i++) {
                string[] splittedRow = rows[i].Split(',');

                Weblink newLink = new Weblink();
                newLink.länknamn = splittedRow[0];
                newLink.beskrivning = splittedRow[1];
                newLink.URL = splittedRow[2];
                links[i] = (newLink);
            }

            bool linkNameNotFound = true;

            foreach (Weblink link in links) {
                if (string.Compare(linkName, link.länknamn ) == 0) {
                    Process proc = new Process();
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = link.URL;
                    proc.Start();
                    proc.WaitForExit();
                    linkNameNotFound = false;
                    break;
                }
            }
            if (linkNameNotFound) {
                Console.WriteLine("Linkname could not be found!");
            }
            
            
        }

        private static void LoadFile(string file)
        {
            string[] rader = File.ReadAllLines($"..\\..\\..\\{file}.txt");
            Weblink[] Länkar = new Weblink[rader.Length];
            int a = 0;
            foreach (string r in rader)
            {
                string[] delar = r.Split (',');
                Länkar[a] = new Weblink()
                {
                    länknamn = delar[0],
                    beskrivning = delar[1],
                    URL = delar[2],
                };
                /*int j = 0;
                foreach (string del in delar) {
                    Console.WriteLine(delar[j]);
                    j++;*/
                Console.WriteLine("------------------------------------------");
                Länkar[a].Print();
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
                "add link  -  add a new link",
                "zadd link - add a new link with zenity",
                "new file name  -  create a new file"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
        
    }
}