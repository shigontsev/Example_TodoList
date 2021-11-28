using Dependencies;
using Entities;
using System;

namespace PL.ConsolePL
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var a=DependencyResolver.Instance.TodoListLogic;

            //var note = new Note(
            //    name: "Поесть",
            //    priority: Priority.VeryHigh,
            //    text: "Поесть очень вкусно завтрак");

            //a.Add(note);

            //foreach (var item in a.GetAll())
            //{
            //    Console.WriteLine(item);
            //}

            var menu = new Menu();
            menu.CallMenu();

            Console.ReadLine();
        }
    }
}
