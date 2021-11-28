using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IСompletedTasksDAO
    {
        /// <summary>
        /// Выполнить Задачу по его Id
        /// </summary>
        /// <param name="id"></param>
        bool Complete(Guid id);

        //void GetAll();

        List<Note> GetAllCompleted();

        List<Note> GetAllUnCompleted();


    }
}
