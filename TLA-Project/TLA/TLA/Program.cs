using System;

namespace TLA
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Input
            while (true)
            {
                Console.WriteLine("Welcome, Which language do you want to test? (Enter a number from 1 to 5)");
                int n = int.Parse(Console.ReadLine());

                if (n > 5 | n < 1) Console.WriteLine("Wrong number, the number must be from 1 to 5!");
                else
                {
                    Q L = new L2();
                    switch (n)
                    {
                        case 1:
                            L = new Q1.L1();
                            break;
                        case 2:
                            L = new L2();
                            break;
                        case 3:
                            L = new L3();
                            break;
                        case 4:
                            L = new L4();
                            break;
                        case 5:
                            L = new L5();
                            break;
                    }
                    Console.WriteLine("You choosed : L" + n);
                    Console.WriteLine("Enter your input string: ");
                    string w = Console.ReadLine();
                    string Result = L.CheckString(w);
                    Console.WriteLine(Result);
                    Console.WriteLine();
                    Console.WriteLine("Do you want to test something again? (Y|N)");
                    string YN = Console.ReadLine();
                    if (YN.Equals("N") | YN.Equals("n"))
                    {
                        Console.WriteLine("\nThanks, Good luck!");
                        Environment.Exit(3);
                        break;
                    }
                    Console.WriteLine();
                }
            }
            #endregion Input
        }
    }
}
