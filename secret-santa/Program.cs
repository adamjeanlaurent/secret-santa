using System;
using System.Collections.Generic;

namespace secretsanta
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employees SecretSanta = new Employees(("/Users/ajean-laurent/desktop/programming_projects/secret-santa/secret-santa/Pairs.txt"));
            //SecretSanta.GetEmployeesFromCommandLine();
            SecretSanta.GetEmployeesFromFile("/Users/ajean-laurent/desktop/programming_projects/secret-santa/secret-santa/InputEmployeeFile.txt");
            SecretSanta.AssignAllRandomEmployees();
            SecretSanta.WritePairsToFile();
        }
    }
}
