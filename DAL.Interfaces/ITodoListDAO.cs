using Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ITodoListDAO
    {
        /// <summary>
        /// Вывести весь перечень задач
        /// </summary>
        /// <returns></returns>
        List<Note> GetAll();

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="note"></param>
        void Add(Note note);

        /// <summary>
        /// Удалить задачу по его Id
        /// </summary>
        /// <param name="id"></param>
        bool Remove(Guid id);

        /// <summary>
        /// Удалить задачу по его Index
        /// </summary>
        /// <param name="index"></param>
        bool RemoveAt(int index);

        /// <summary>
        /// Сортировка задач по Priority
        /// </summary>
        void SortByPriority();

        /// <summary>
        /// Вывести список Задач по SubName
        /// </summary>
        /// <param name="subName"></param>
        /// <returns></returns>
        List<Note> GetBySubName(string subName);

        /// <summary>
        /// Вернуть Задачу по его Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Note GetByName(string name);

        /// <summary>
        /// Вернуть Задачу по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Note GetById(Guid id);
    }
}
