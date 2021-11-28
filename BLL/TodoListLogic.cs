using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TodoListLogic : ITodoListLogic
    {
        private ITodoListDAO _todoListDAO;

        public TodoListLogic(ITodoListDAO todoListDAO)
        {
            _todoListDAO = todoListDAO;
        }

        public void Add(Note note)
        {
            _todoListDAO.Add(note);
        }

        public List<Note> GetAll()
        {
            return _todoListDAO.GetAll();
        }

        public Note GetById(Guid id)
        {
            return _todoListDAO.GetById(id);
        }

        public Note GetByName(string name)
        {
            return _todoListDAO.GetByName(name);
        }

        public bool Remove(Guid id)
        {
            return _todoListDAO.Remove(id);
        }

        public bool Remove(Note note)
        {
            return Remove(note.Id);
        }

        public bool RemoveAt(int index)
        {
            return _todoListDAO.RemoveAt(index);
        }

        public void SortByPriority()
        {
            _todoListDAO.SortByPriority();
        }
    }
}
