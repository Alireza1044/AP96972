using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoteViewModel
    {
        public NoteViewModel() { }

        public NoteViewModel(string name,string description,string id)
        {
            Name = name;
            Description = description;
            ID = id;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
    }
}
