using System;
using System.Collections.Generic;
using System.IO;

namespace secretsanta
{
    public class Employees
    {
        private List<string> ListOfEmployees;
        private List<string> Pairs;
        public string filePath;

        public Employees(string filePath)
        {
            this.ListOfEmployees = new List<string>();
            this.Pairs = new List<string>();
            this.filePath = filePath;
        }

        public void DisplayMenu()
        {
            string userInput = "";
            SetTerminalToChristmasColors();
            Introduction();

            while (userInput != "done")
            {
                Console.WriteLine("Press 1. To Manually Type Employees Here In The Command Line");
                Console.WriteLine("Press 2. To Input Employees Via A Text File");

                userInput = Console.ReadLine();

                if(userInput == "1")
                {
                    GetEmployeesFromCommandLine();
                    AssignAllRandomEmployees();
                    break;
                }

                else if(userInput == "2")
                {
                    Console.Write("File To Read From: ");
                    string fileToReadFrom = Console.ReadLine();
                    fileToReadFrom = Path.GetFullPath(fileToReadFrom);
                    GetEmployeesFromFile(fileToReadFrom);
                    AssignAllRandomEmployees();
                    break;
                }

                else if(userInput == "done")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
           
        public void GetEmployeesFromCommandLine()
        {
            string userInput = "";
            while(userInput != "-1")
            {
                Console.Write("Employee # {0}: ", ListOfEmployees.Count + 1);
                userInput = Console.ReadLine();
                if (userInput == "-1")
                {
                    if (ListOfEmployees.Count % 2 != 0)
                    {
                        Console.WriteLine("You Must Enter An Even Amount Of Employees");
                        userInput = "";
                        continue;
                    }
                    break;
                }
                ListOfEmployees.Add(userInput);
            }
        }

        public void GetEmployeesFromFile(string inputFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(inputFilePath);


            if (lines.Length % 2 != 0)
            {
                Console.WriteLine("Can't Assign, There Must Be An Even Amount Of Lines In The File!");
                return;
            }

            if (lines.Length == 0)
            {
                Console.WriteLine("Can't Assign, List Of Employees Is Empty!");
                return;
            }

            foreach (string line in lines)
            {
                ListOfEmployees.Add(line);
            }
            Console.WriteLine("Done! Visit File To View! Happy Holidays!");
        }

        public void AssignAllRandomEmployees()
        {
            if(ListOfEmployees.Count == 0)
            {
                Console.WriteLine("List Of Employees Is Empty! Cannot Assign :(");
                return;
            }

            if(ListOfEmployees.Count % 2 != 0)
            {
                Console.WriteLine("Cannot Assign, There Are An Odd Number Of Employees :(");
                return;
            }

            Console.WriteLine("Processing....");

            System.Threading.Thread.Sleep(5000);

            while (ListOfEmployees.Count != 0)
            {
                int firstRandNum = GenRandNum();
                int secondRandNum = GenRandNum();
                while (secondRandNum == firstRandNum)
                    secondRandNum = GenRandNum();
                string firstNameToBeRemoved = ListOfEmployees[firstRandNum];
                string secondNameToBeRemoved = ListOfEmployees[secondRandNum];
                Pairs.Add(ListOfEmployees[firstRandNum] + " Is Paired With " + ListOfEmployees[secondRandNum]);
                ListOfEmployees.Remove(firstNameToBeRemoved);
                ListOfEmployees.Remove(secondNameToBeRemoved);
            }
            Console.WriteLine("Done! Visit File To View! Happy Holidays!");
        }

        public void WritePairsToFile()
        {
            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (string pair in Pairs)
                {
                    file.WriteLine(pair);
                }
            }
            Pairs = new List<string>();
        }

        private int GenRandNum()
        {
            Random r = new Random();
            return r.Next(0, ListOfEmployees.Count);
        }

        private void SetTerminalToChristmasColors()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
        }

        private void Introduction()
        {
            Console.WriteLine("       ____");
            Console.WriteLine("     {} _  \\");
            Console.WriteLine("   |__ \\");
            Console.WriteLine("   /_____\\");
            Console.WriteLine("     \\o o)\\)_______");
            Console.WriteLine("     (<  ) /#######\\");
            Console.WriteLine("    __{'~` }#########|");
            Console.WriteLine("   /  {   _}_/########|");
            Console.WriteLine(" /   {  / _|#/ )####|");
            Console.WriteLine(" /   \\_~/ /_ \\  |####|");
            Console.WriteLine(" \\______\\/  \\ | |####|");
            Console.WriteLine(" \\__________\\|/#####|");
            Console.WriteLine(" |__[X]_____/ \\###/ ");
            Console.WriteLine(" /___________\\");
            Console.WriteLine(" |    |/    |");
            Console.WriteLine(" |___/ |___/");
            Console.WriteLine("_|   /_|   /");
            Console.WriteLine("(___,_(___,_)");

            Console.WriteLine("\n\nHAPPY HOLIDAYS!!\n\n");
        }
    }
}
