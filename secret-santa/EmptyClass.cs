using System;
namespace secretsanta
{
    public class SecretSantaPair
    {
        string person1;
        string person2;

        public SecretSantaPair(string p1 , string p2)
        {
            this.person1 = p1;
            this.person2 = p2;
        }

        public void printPair()
        {
            Console.WriteLine(this.person1 + " Is Paired With " + this.person2);
        }
    }
}
