using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonDAL
{
    public class TodoListDAO : ITodoListDAO
    {
        //private List<Note> _content;

        private string _filePath;

        public TodoListDAO()
        {
            _filePath = "";
            //_content = JsonDAO<Note>.Deserialize(_filePath);
        }

        public void Add(Note note)
        {
            var notes = GetAll();
            notes.Add(note);

            JsonDAO<Note>.Serialize(_filePath, notes);
        }

        //public void CompleteTask(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Note> GetAll()
        {
            return JsonDAO<Note>.Deserialize(_filePath);
        }

        public Note GetById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Note GetByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Name == name);
        }

        public List<Note> GetBySubName(string subName)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid id)
        {
            var note = GetById(id);
            if (note != null)
            {
                var notes = GetAll();
                notes.Remove(note);
                JsonDAO<Note>.Serialize(_filePath, notes);

                return true;
            }
            
            return false;
        }

        public void SortByPriority()
        {
            var notes = GetAll().OrderBy(x => x.Priority).ToList();
            JsonDAO<Note>.Serialize(_filePath, notes);
        }
    }
}
