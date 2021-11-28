using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NoteCompleted
    {

        public Note Note { get; private set; }

        public bool IsCompleted { get; private set; }

        //public NoteCompleted()
        //{
        //}

        public NoteCompleted(Note note, bool isCompleted)
        {
            Note = note;
            IsCompleted = isCompleted;
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, new string[]{
                Note.ToString(),
                $"Выполнено = {IsCompleted}"
            });
        }

        public string ShowShortInfo()
        {
            return String.Join("; ", new string[]{
                Note.ShowShortInfo(),
                $"Выполнено = {IsCompleted}"
            });
        }

        public string ShowFullInfo()
        {
            return String.Join(Environment.NewLine, new string[]{
                Note.ShowFullInfo(),
                $"Выполнено = {IsCompleted}"
            });
        }
    }
}
