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
        private List<Note> _content;

        private string _filePath;

        public TodoListDAO()
        {
            _filePath = "";
            _content = JsonDAO<Note>.Deserialize(_filePath);
        }

        public void Add(Note note)
        {
            _content.Add(note);
            SortByPriority();

            JsonDAO<Note>.Serialize(_filePath, _content);
        }

        //public void CompleteTask(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Note> GetAll()
        {
            return _content.ToList();
        }

        public Note GetById(Guid id)
        {
            return _content.FirstOrDefault(x => x.Id == id);
        }

        public Note GetByName(string name)
        {
            return _content.FirstOrDefault(x => x.Name == name);
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
                _content.Remove(note);
                JsonDAO<Note>.Serialize(_filePath, (List<Note>)_content);

                return true;
            }
            
            return false;
        }

        public void SortByPriority()
        {
            _content = _content.OrderBy(x => x.Priority).ToList();
        }
    }
}
