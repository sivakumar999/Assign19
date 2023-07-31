using System;


public delegate int ArithmeticOperation(int a, int b);

public class Program
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        return a / b;
    }

    public static void Main(string[] args)
    {
        ArithmeticOperation addDelegate = Add;
        ArithmeticOperation subtractDelegate = Subtract;
        ArithmeticOperation multiplyDelegate = Multiply;
        ArithmeticOperation divideDelegate = Divide;

        while (true)
        {
            Console.WriteLine("Choose an arithmetic operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 5)
            {
                Console.WriteLine("Exiting the program.");
                break;
            }

            if (choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            Console.Write("Enter the first integer: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int num2 = int.Parse(Console.ReadLine());

            int result = 0;

            switch (choice)
            {
                case 1:
                    result = addDelegate(num1, num2);
                    break;
                case 2:
                    result = subtractDelegate(num1, num2);
                    break;
                case 3:
                    result = multiplyDelegate(num1, num2);
                    break;
                case 4:
                    result = divideDelegate(num1, num2);
                    break;
            }

            Console.WriteLine("Result: " + result);
        }
    }
}
