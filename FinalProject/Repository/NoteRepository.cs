using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NoteRepository : BaseRepository
    {
        public void NewNote(Note note)
        {
            Context.Notes.Add(note);
            Context.SaveChanges();
        }

        public void RemoveNote(Note note)
        {
            Context.Entry(note).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
        }

        public List<Note> NotesList()
        {
            var notes = Context.Notes.ToList();
            return notes;
        }

        public Note GetNote(string ID)
        {
            var note = Context.Notes.Where(x => x.ID == ID).SingleOrDefault();
            return note;
        }

        public void UpdateNote(Note note)
        {
            Context.Entry(note).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
