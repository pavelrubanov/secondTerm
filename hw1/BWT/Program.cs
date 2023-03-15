using BWT_;
using System;

namespace Program
{
    class Program
    {
        public static void Main()
        {
            if (!Test())
            {
                Console.WriteLine("Tests failed");
                return;
            }
        }
        public static bool Test()
        {
            string[] tests = { "123", "BANANA", "ABACABA" };
            for (int i = 0; i < tests.Length; i++)
            {
                if (BWT.Decode(BWT.Encode(tests[i])) != tests[i]) return false;
            }
            return true;
        }
    }
}