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

        public NoteViewModel(string name,string description,string id,string lc,string dc)
        {
            Name = name;
            Description = description;
            ID = id;
			LightColor = lc;
			DarkColor = dc;
        }

        public string Name { get; set; }
        public string Description { get; set; }
		public string LightColor { get; set; }
		public string DarkColor { get; set; }
		public string ID { get; set; }
    }
}
