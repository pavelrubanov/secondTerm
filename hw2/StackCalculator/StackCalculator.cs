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
        /// <summary>
        /// Returns the result of computing an expression
        /// </summary>
        /// <param name="expression">Only postfix notation</param>
        /// <param name="stack"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DivideByZeroException"></exception>
        public static double Calculate(string expression, IStack stack)
        {
            if (!stack.IsEmpty())
            {
                throw new ArgumentException("Stack should be empty");
            }

            if (expression == null)
            {
                throw new ArgumentNullException();
            }

            if (expression == "")
            {
                throw new ArgumentException("Empty expression");
            }

            var dictionary = "0123456789/*-+ ";
            foreach (var symbol in expression)
            {
                if (!dictionary.Contains(symbol))
                {
                    throw new ArgumentException("Incorrect symbols in expression");
                }
            }

            var operations = new Dictionary<string, Func<double, double, double>>();
            operations.Add("+", (x, y) => x + y);
            operations.Add("-", (x, y) => x - y);
            operations.Add("*", (x, y) => x * y);
            operations.Add("/", (x, y) =>
            {
                if (Math.Abs(y) < 1e-9)
                {
                    throw new DivideByZeroException();
                }
                return x / y;
            }
            );

            foreach (var element in expression.Split())
            {
                if (int.TryParse(element, out int number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (operations.ContainsKey(element))
                    {
                        try
                        {
                            var number2 = stack.Pop();
                            var number1 = stack.Pop();
                            stack.Push(operations[element](number1,number2));
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
