using Entities;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IСompletedTasksDAO
    {
        /// <summary>
        /// Выполнить Задачу по его Id
        /// </summary>
        /// <param name="id"></param>
        bool Complete(Guid id);

        /// <summary>
        /// Выполнить первую приоритетную задачу
        /// </summary>
        /// <returns></returns>
        bool CompleteTop(out Note note);

        List<NoteCompleted> GetAll();

        List<Note> GetAllCompleted();

        List<Note> GetAllUnCompleted();


    }
}
