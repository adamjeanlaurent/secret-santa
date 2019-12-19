using System;
using System.Collections.Generic;

namespace secretsanta
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> IDToEmployee = new Dictionary<int, string>(); 
            string input = "";
            while(true)
            {
                Console.Write("Enter Employee Name: ");
                input = Console.ReadLine();

                if (input == "done")
                    break;
                 
                IDToEmployee.Add(IDToEmployee.Count + 1, input);
            }

            SecretSantaPair[] EmployeePairs = new SecretSantaPair[] {};
            HashSet<int> AlreadyPairedIDs = new HashSet<int>();
            
            while(AlreadyPairedIDs.Count != EmployeePairs.Length)
            {
               
            }
        }

        public static int genRandNum(int lowerBound, int upperBound)
        {
            Random r = new Random();
            return r.Next(lowerBound, upperBound + 1);
        }
    }
}
