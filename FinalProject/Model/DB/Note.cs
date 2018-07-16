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

        public Note(string name,string description,string id)
        {
            Description = description;
            Name = name;
            ID = id;
        }

        
        public string Name { get; set; }
        public string Description { get; set; }
        [Key] public string ID { get; set; }
    }
}
