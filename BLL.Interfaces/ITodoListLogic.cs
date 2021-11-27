﻿using Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITodoListLogic
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
        /// Удалить задачу
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool Remove(Note note);

        /// <summary>
        /// Сортировка задач по Priority
        /// </summary>
        void SortByPriority();

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