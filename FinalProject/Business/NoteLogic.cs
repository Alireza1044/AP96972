using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business
{
    public class NoteLogic
    {
        NoteRepository noteRepository = new NoteRepository();

        public NoteLogic()
        {
                FinalProject.Mapping.init();
        }

        public void NewNote(NoteViewModel noteViewM)
        {
            var note = Mapper.Map<Note>(noteViewM);
            noteRepository.NewNote(note);
        }

        public void RemoveNote(NoteViewModel noteViewM)
        {
            noteRepository.RemoveNote(noteRepository.GetNote(noteViewM.ID.ToString()));
        }

        public List<NoteViewModel> NotesList()
        {
            var notes = noteRepository.NotesList();
            var result = Mapper.Map<List<NoteViewModel>>(notes);
            return result;
        }

        public NoteViewModel GetNote(Note note)
        {
            var _note = Mapper.Map<NoteViewModel>(note);
            return _note;
        }

        public void UpdateNote(NoteViewModel noteViewM)
        {
            var note = noteRepository.GetNote(noteViewM.ID.ToString());
            note.Name = noteViewM.Name.ToString();
            note.Description = noteViewM.Description.ToString();
            noteRepository.UpdateNote(note);
        }
    }
}
