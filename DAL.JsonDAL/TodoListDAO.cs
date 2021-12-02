using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.JsonDAL
{
    public class TodoListDAO : ITodoListDAO
    {
        private string _filePath_Notes;

        public TodoListDAO()
        {
            _filePath_Notes = FilePath.JsonNotesPath;
        }

        public void Add(Note note)
        {
            var notes = GetAll();
            notes.Add(note);

            //JsonDAO<Note>.Serialize(_filePath_Notes, notes.OrderBy(x => x.Priority).ToList());
            JsonDAO<Note>.Serialize(_filePath_Notes, notes);
        }

        public List<Note> GetAll()
        {
            return JsonDAO<Note>.Deserialize(_filePath_Notes);
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
            var reg = new Regex($"{subName}.*",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var notes = GetAll();
            var result = new List<Note>();
            
            foreach (var note in notes)
            {
                Match m = reg.Match(note.Name);
                if (m.Success)
                {
                    result.Add(note);
                }
            }

            return result;
        }

        public bool Remove(Guid id)
        {
            var note = GetById(id);
            if (note != null)
            {
                var notes = GetAll().Where(x => x.Id != note.Id).ToList();
                JsonDAO<Note>.Serialize(_filePath_Notes, notes);

                return true;
            }
            
            return false;
        }

        public bool RemoveAt(int index)
        {
            var notes = GetAll();

            if (index < notes.Count)
            {
                notes.RemoveAt(index);
                JsonDAO<Note>.Serialize(_filePath_Notes, notes);

                return true;
            }

            return false;
        }

        public void SortByPriority()
        {
            var notes = GetAll().OrderBy(x => x.Priority).ToList();
            JsonDAO<Note>.Serialize(_filePath_Notes, notes);
        }
    }
}
