using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("notes")]
    public class Note
    {
        public Note() { }

        public Note(string name,string description,string id,string lc,string dc)
        {
            Description = description;
            Name = name;
            ID = id;
			DarkColor = dc;
			LightColor = lc;
        }

        
        public string Name { get; set; }
        public string Description { get; set; }
		public string LightColor { get; set; }
		public string DarkColor { get; set; }
        [Key] public string ID { get; set; }
    }
}
