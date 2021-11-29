using System;

namespace PL.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var menu = new Menu();
            menu.CallMenu();

            Console.WriteLine(Environment.NewLine + "Програма завершена, введите любую клавишу");
            Console.ReadLine();
        }
    }
}
