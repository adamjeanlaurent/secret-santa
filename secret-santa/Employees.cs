using System;
using System.Collections.Generic;
using System.IO;

namespace secretsanta
{
    public class Employees
    {

        private List<string> ListOfEmployees;
        private List<string> Pairs;

        public Employees()
        {
            this.ListOfEmployees = new List<string>();
            this.Pairs = new List<string>();
        }

        public void GetEmployees()
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

        public void AssignAllRandomEmployees()
        { 
            while(ListOfEmployees.Count != 0)
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
        }

        public void WritePairsToFile()
        {
            using (StreamWriter file = new StreamWriter("/Users/ajean-laurent/desktop/programming_projects/secret-santa/secret-santa/Pairs.txt"))
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
    }
}
