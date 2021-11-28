using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompletedTasksLogic
    {
        /// <summary>
        /// Выполнить Задачу по его Id
        /// </summary>
        /// <param name="id"></param>
        bool Complete(Guid id);

        List<Note> GetAllCompleted();

        List<Note> GetAllUnCompleted();
    }
}
