using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign19._2
{
    /*delegate T Operation<T>(T a, T b);
    class Program
    {
        static T Add<T>(T a, T b) => (dynamic)a + (dynamic)b;
        static T Subtract<T>(T a, T b) => (dynamic)a - (dynamic)b;
        static T Multiply<T>(T a, T b) => (dynamic)a * (dynamic)b;
        static T Divide<T>(T a, T b) => (dynamic)a / (dynamic)b;
        static dynamic ReadInput()
        {
            while (true)
            {
                try
                {
                    return Convert.ChangeType(Console.ReadLine(), typeof(double));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, Please try again");
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter value 1");
                dynamic num1 = ReadInput();
                Console.WriteLine("Enter value 2");
                dynamic num2 = ReadInput();
                Console.WriteLine("Choose an operation");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                int choice = int.Parse(Console.ReadLine());
                Operation<dynamic> operation = null;
                switch (choice)
                {
                    case 1:
                        operation = Add;
                        break;
                    case 2:
                        operation = Subtract;
                        break;
                    case 3:
                        operation = Multiply;
                        break;
                    case 4:
                        operation = Divide;
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program, press any key");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid choice, Try again");
                        continue;
                }
                if (operation != null)
                {
                    try
                    {
                        dynamic result = operation(num1, num2);
                        Console.WriteLine("Result: " + result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }*/

    public delegate T Operation<T>(T a, T b);

    public class Calculator
    {
        public static T Add<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }

        public static T Subtract<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x - y;
        }

        public static T Multiply<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x * y;
        }

        public static T Divide<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;

            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return x / y;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose a data type:");
                Console.WriteLine("1. Integer");
                Console.WriteLine("2. Double");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 3)
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                if (choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                if (choice == 1)
                {
                    PerformOperation<int>();
                }
                else if (choice == 2)
                {
                    PerformOperation<double>();
                }
            }
        }

        public static void PerformOperation<T>()
        {
            Console.Write("Enter the first value: ");
            string value1Str = Console.ReadLine();

            Console.Write("Enter the second value: ");
            string value2Str = Console.ReadLine();

            try
            {
                T value1 = (T)Convert.ChangeType(value1Str, typeof(T));
                T value2 = (T)Convert.ChangeType(value2Str, typeof(T));

                Operation<T> operation = null;
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");

                int operationChoice = int.Parse(Console.ReadLine());

                switch (operationChoice)
                {
                    case 1:
                        operation = Calculator.Add;
                        break;
                    case 2:
                        operation = Calculator.Subtract;
                        break;
                    case 3:
                        operation = Calculator.Multiply;
                        break;
                    case 4:
                        operation = Calculator.Divide;
                        break;
                    default:
                        Console.WriteLine("Invalid operation choice.");
                        return;
                }

                T result = operation(value1, value2);
                Console.WriteLine("Result: " + result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numeric values.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
