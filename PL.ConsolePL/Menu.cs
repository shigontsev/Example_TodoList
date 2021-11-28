﻿using BLL.Interfaces;
using Dependencies;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PL.ConsolePL
{
    public class Menu
    {
        private DependencyResolver Bd;

        private ITodoListLogic bdTodoList;

        private ICompletedTasksLogic bdCompletedList;

        public Menu()
        {
            Bd = DependencyResolver.Instance;
            bdTodoList = Bd.TodoListLogic;
            bdCompletedList = Bd.CompletedTasksLogic;
        }

        public void CallMenu()
        {
            string[] contentMenu = {
                "Выберите следующее:",
                "1 : Посмотреть список дел",
                "2 : Добавить дело",
                "3 : Удалить дело",
                "4 : Сортировать список по Приоритету",
                "5 : Найти дело",
                "6 : Выподнить выбранное дело",
                "7 : Список выполненых дел",
                "8 : Список невыполненых дел",
                "Ввод \'q\' Выйти из приложения",
                "ENTER: "
            };

            //string[] contentMenu_Resetter = {
            //    "Выбран откат изменений",
            //    "Выберите следующее:",
            //    "1 : Откат по индексу фиксации",
            //    "2 : Откат по выбранной дате и времени",
            //    "Ввод \'q\' Вернуться назад", "ENTER: "
            //};

            //MenuAction
            //DelegateMenu(contentMenu,
            //    ShowTodoList,
            //    () => DelegateMenu(contentMenu_Resetter,
            //            Resetter.Run_Fixation,
            //            Resetter.Run_SelectResetByDate));
            DelegateMenu(contentMenu,
                ShowTodoList,
                AddTask,
                RemoveTask,
                SortTasks,
                SearchTaskByName,
                CompleteTask,
                ShowCompletedTasks, 
                ShowUnCompletedTasks
                );
        }

        private void DelegateMenu(string[] contentMenu, params Action[] action)
        {
            string commandButton = "";
            do
            {
                Console.Clear();
                Console.WriteLine(string.Join(Environment.NewLine, contentMenu));

                commandButton = Console.ReadLine();
                if (int.TryParse(commandButton, out int index) && (index > 0 && index <= action.Length))
                {
                    action[index - 1]?.Invoke();
                }

            } while (commandButton != "q");
        }

        private void PrintTodoList()
        {
            var todoList = bdTodoList.GetAll();

            Console.WriteLine("Список дел:");
            int index = 0;
            foreach (var item in todoList)
            {
                Console.WriteLine($"№{index} : {item.ShowNameAndPriority()}");
                index++;
            }
        }

        private void ShowTodoList()
        {
            PrintTodoList();
            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void AddTask()
        {
            //Note note;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите название задачи: ");
                    var name = Console.ReadLine().Trim();
                    Console.WriteLine("Введите описание задачи: ");
                    var text = Console.ReadLine().Trim();
                    Note note = new Note(
                        name: name,
                        text: text,
                        priority: TurnPriority()
                        );
                    bdTodoList.Add(note);

                    Console.WriteLine($"Добавлена задача { note.ShowNameAndPriority()}");

                    Console.Write("Введите любую кнопку чтобы вернуться:");
                    Console.ReadLine();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Повторите попытку =)");
                }
            }
        }

        private Priority TurnPriority()
        {
            while(true)
            {
                Console.WriteLine("Выберите приоретет задания 1-5: ");
                try
                {
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1: return Priority.VeryHigh; break;
                        case 2: return Priority.High; break;
                        case 3: return Priority.Medium; break;
                        case 4: return Priority.Low; break;
                        case 5: return Priority.VeryLow; break;
                        default:
                            Console.WriteLine("Нет такого приоритета повторите попытку!!!");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введен не правильный формат приоритета повторите попытку!!!");
                }
            }
        }

        private void RemoveTask()
        {
            PrintTodoList();

            Console.WriteLine("Введите номер № задачи, которую хотите удалить: ");
            var notes = bdTodoList.GetAll();

            //var a = int.TryParse(Console.ReadLine(), out int index);



            //while (!int.TryParse(Console.ReadLine(), out int index) && !(index>=notes.Count || index < 0))
            //{
            //    Console.WriteLine("Неверный введеный формат индекса или индекс вышел за границу, повторите попытку");
            //}
            //bool b = false
            //    do
            //{

            //}while()
            //back:
            var b = int.TryParse(Console.ReadLine(), out int index);

            if (b)
            {
                try
                {
                    var note = notes[index];
                    if(bdTodoList.RemoveAt(index))
                    {
                        Console.WriteLine($"{note.ShowNameAndPriority()} успешно удален");
                    }
                    else
                    {
                        Console.WriteLine($"{note.ShowNameAndPriority()} неудачная попытка удаления");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Index вышел за диапозон");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода значения");
            }
            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void SortTasks()
        {
            bdTodoList.SortByPriority();


            Console.Write("Сортирвка списка выполнина успешно " +
                Environment.NewLine +
                "Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void SearchTaskByName()
        {
            //PrintTodoList();

            Console.WriteLine("Введите название задачи: ");
            var name = Console.ReadLine().Trim();
            var note = bdTodoList.GetByName(name);

            if (note == null)
            {
                Console.WriteLine("Такой задачи не существует");
            }
            else
            {
                Console.WriteLine(note);
            }

            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void CompleteTask()
        {
            PrintTodoList();
            Console.WriteLine("Введите № задачи которую следует выполнить: ");
            var notes = bdTodoList.GetAll();
            var b = int.TryParse(Console.ReadLine(), out int index);

            if (b)
            {
                try
                {
                    var note = notes[index];
                    if (bdCompletedList.Complete(note.Id))
                    {
                        Console.WriteLine($"{note.ShowNameAndPriority()} успешно выполнено");
                    }
                    else
                    {
                        Console.WriteLine($"{note.ShowNameAndPriority()} такая задача уже выполнена");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Index вышел за диапозон");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ввода значения");
            }
            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void ShowCompletedTasks()
        {
            var todoList = bdCompletedList.GetAllCompleted();

            Console.WriteLine("Список выполненных дел:");
            int index = 0;
            foreach (var item in todoList)
            {
                Console.WriteLine($"№{index} : {item.ShowNameAndPriority()}");
                index++;
            }
            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }

        private void ShowUnCompletedTasks()
        {
            var todoList = bdCompletedList.GetAllUnCompleted();

            Console.WriteLine("Список невыполненных дел:");
            int index = 0;
            foreach (var item in todoList)
            {
                Console.WriteLine($"№{index} : {item.ShowNameAndPriority()}");
                index++;
            }
            Console.Write("Введите любую кнопку чтобы вернуться:");
            Console.ReadLine();
        }
    }
}