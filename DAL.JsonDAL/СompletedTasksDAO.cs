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

        private List<Guid> _content;

        private string _filePath_Notes;

        private string _filePath_СompletedTasks;

        public СompletedTasksDAO()
        {
            _filePath_СompletedTasks = "";
            _filePath_Notes = "";
            _content = JsonDAO<Guid>.Deserialize(_filePath_СompletedTasks);
        }

        public void Complete(Guid id)
        {
            if (!_content.Contains(id))
            {
                _content.Add(id);
            }
        }

        public List<Note> GetAllCompleted()
        {
            var notes = JsonDAO<Note>.Deserialize(_filePath_Notes);
            //var a = notes.Join
            return null;
        }

        public List<Note> GetAllUnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
