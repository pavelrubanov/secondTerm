using StackCalculator;
using System;

namespace StackCalculator.Program
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Write a math expression");
            string expression = Console.ReadLine();

            try
            {
                var stack1 = new StackOnLinkedList();
                var stack2 = new StackOnList();
                var result1 = StackCalculator.Calculate(expression, stack1);
                var result2 = StackCalculator.Calculate(expression, stack2);
                Console.WriteLine("Result from calculator with StackOnLinkedList: " + result1);
                Console.WriteLine("Result from calculator with StackOnList: " + result2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

}