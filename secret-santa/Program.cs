using System;
using System.Collections.Generic;

namespace secretsanta
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Employees SecretSanta = new Employees();
            SecretSanta.GetEmployees();
            SecretSanta.AssignAllRandomEmployees();
            SecretSanta.WritePairsToFile();
        }
    }
}
