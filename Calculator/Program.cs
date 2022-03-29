using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор");
            char again = 'д';
            while (again == 'д')
            {
                double a;
                double b;
                double rez;
                char oper;

                Console.WriteLine("Введите первое число:");
                a = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите оператор(| + | -  | * | / |):");
                oper = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                b = Convert.ToDouble(Console.ReadLine());

                if (oper == '+')
                {
                    rez = a + b;
                    Console.WriteLine(a + " + " + b + " = " + rez + ".");
                }

                else if (oper == '-')
                {
                    rez = a - b;
                    Console.WriteLine(a + " - " + b + " = " + rez + ".");
                }

                else if (oper == '*')
                {
                    rez = a * b;
                    Console.WriteLine(a + " * " + b + " = " + rez);
                }

                else if (oper == '/')
                {
                    rez = a / b;
                    Console.WriteLine(a + " / " + b + " = " + rez);
                }
                else
                {
                    Console.WriteLine("Неизвестный оператор.");
                }
                Console.WriteLine("Вы хотите продолжить работу с калькулятором? (д/н)");
                again = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
