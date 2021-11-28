using System;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Note
    {
        public Guid Id { get; }

        [JsonIgnore]
        private string _name;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), $"Аргумент {nameof(Name)} не должен быть пустым");
                }
                _name = value;
            }
        }

        [JsonIgnore]
        private Priority _priority;

        public Priority Priority
        {
            get { return _priority; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Priority), $"Аргумент {nameof(Priority)} должен быть в диапозоне VeryHigh...VeryLow (1...5)");
                }
                _priority = value;
            }
        }

        [JsonIgnore]
        private string _text;

        public string Text
        {
            get { return _text; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) )
                {
                    throw new ArgumentNullException(nameof(Text), $"Аргумент {nameof(Text)} не должен быть пустым");
                }
                _text = value;
            }
        }


        public Note(Guid id, string name, Priority priority, string text)
        {
            Id = id;
            Name = name;
            Priority = priority;
            Text = text;
        }

        public Note(string name, Priority priority, string text)
        {
            Id = Guid.NewGuid();
            Name = name;
            Priority = priority;
            Text = text;
        }

    }
}
