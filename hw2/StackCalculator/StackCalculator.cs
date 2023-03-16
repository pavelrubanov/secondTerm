using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public static class StackCalculator
    {
        public static double Calculate(string expression, IStack stack)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }

            var dictionary = "0123456789/*-+ ";
            if (!(expression.All(el => dictionary.Contains(el))))
            {
                throw new ArgumentException("Incorrect symbols in expression");
            }

            var operations = "/*-+";
            foreach (var element in expression.Split(" "))
            {
                if (double.TryParse(element, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (operations.Contains(element))
                    {
                        try
                        {
                            var number1 = stack.Pop();
                            var number2 = stack.Pop();
                            switch(element)
                            {
                                case "+":
                                    stack.Push(number1 + number2);
                                    break;
                                case "-":
                                    stack.Push(number1 - number2);
                                    break;
                                case "*":
                                    stack.Push(number1 * number2);
                                    break;
                                case "/":
                                    if (Math.Abs(number2) < 1e-9)
                                    {
                                        throw new DivideByZeroException();
                                    }
                                    break;
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            throw new ArgumentException("Incorrect expression");
                        }
                    }
                }
            }
            var result = stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new ArgumentException("Incorrect expression");
            }
            return result;
        }
    }
}
