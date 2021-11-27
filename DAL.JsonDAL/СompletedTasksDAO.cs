using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonDAL
{
    public class СompletedTasksDAO : IСompletedTasksDAO
    {

        //private List<Guid> _content;

        private string _filePath_Notes;

        private string _filePath_СompletedTasks;

        public СompletedTasksDAO()
        {
            _filePath_СompletedTasks = "";
            _filePath_Notes = "";
            //_content = JsonDAO<Guid>.Deserialize(_filePath_СompletedTasks);
        }

        public void Complete(Guid id)
        {
            var idList = GetAllIdCompleted();
            if (!idList.Contains(id))
            {
                idList.Add(id);
                JsonDAO<Guid>.Serialize(_filePath_СompletedTasks, idList);
            }
        }

        private List<Guid> GetAllIdCompleted()
        {
            var idList = JsonDAO<Guid>.Deserialize(_filePath_СompletedTasks);
            return idList;
        }

        private List<Note> GetAllTask()
        {
            var notes = JsonDAO<Note>.Deserialize(_filePath_Notes);
            return notes;
        }

        public List<Note> GetAllCompleted()
        {
            var notes = GetAllTask();
            var idList = GetAllIdCompleted();

            var result = from nts in notes
                         join ids in idList on nts.Id equals ids
                         select new Note(id: nts.Id, name: nts.Name, priority: nts.Priority, text: nts.Text);
            return result.ToList();
        }

        public List<Note> GetAllUnCompleted()
        {
            var notes = GetAllTask();
            var notesCompleted = GetAllCompleted();

            var result = notes.Except(notesCompleted);
            return result.ToList();
        }
    }
}
