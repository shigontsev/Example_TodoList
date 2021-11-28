using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class CompletedTasksLogic : ICompletedTasksLogic
    {
        private IСompletedTasksDAO _сompletedTasksDAO;

        public CompletedTasksLogic(IСompletedTasksDAO сompletedTasksDAO)
        {
            _сompletedTasksDAO = сompletedTasksDAO;
        }

        public bool Complete(Guid id)
        {
            return _сompletedTasksDAO.Complete(id);
        }

        public bool CompleteTop(out Note note)
        {
            return _сompletedTasksDAO.CompleteTop(out note);
        }

        public List<NoteCompleted> GetAll()
        {
            return _сompletedTasksDAO.GetAll();
        }

        public List<Note> GetAllCompleted()
        {
            return _сompletedTasksDAO.GetAllCompleted();
        }

        public List<Note> GetAllUnCompleted()
        {
            return _сompletedTasksDAO.GetAllUnCompleted();
        }
    }
}
