using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Tests
{
    [TestClass()]
    [Table("notesTests")]
    public class NoteLogicTests
    {
        NoteRepository noteRepository = new NoteRepository();
        NoteLogic noteLogic = new NoteLogic();
        Note note = new Note(name, description, time, "#FFCA1F1F", "#FFCA1F1F");

		static string name = "the test title";
        static string description = "this is the test description!";
        static string time = "7/15/2018 6:16:17 PM";
        NoteViewModel _noteViewModel = new NoteViewModel();
        NoteViewModel noteViewModel = new NoteViewModel(name,description,time, "#FFCA1F1F", "#FFCA1F1F");

		[TestMethod()]
        public void NewNoteTest()
        {
            noteLogic.NewNote(noteViewModel);
            Assert.IsTrue(noteRepository.NotesList().Contains(noteRepository.GetNote(noteViewModel.ID)));
            noteLogic.RemoveNote(noteViewModel);
        }

        [TestMethod()]
        public void RemoveNoteTest()
        {
            noteLogic.NewNote(noteViewModel);
            noteLogic.RemoveNote(noteViewModel);
            Assert.IsFalse(noteLogic.NotesList().Contains(noteViewModel));
        }

        [TestMethod()]
        public void GetNoteTest()
        {
            Assert.AreEqual(noteLogic.GetNote(note).Name, noteViewModel.Name);
            Assert.AreEqual(noteLogic.GetNote(note).Description, noteViewModel.Description);
            Assert.AreEqual(noteLogic.GetNote(note).ID, noteViewModel.ID);

        }

        [TestMethod()]
        public void GetNoteListTest()
        {
            var noteList = noteLogic.NotesList();
            noteLogic.NewNote(noteViewModel);
            Assert.AreNotEqual(noteLogic.NotesList(), noteList);
            noteLogic.RemoveNote(noteViewModel);
        }

        [TestMethod()]
        public void UpdateNoteTest()
        {
            noteLogic.NewNote(noteViewModel);
            noteViewModel.Name = "The Great Game";
            noteViewModel.Description = "The Great Game begins now!";
            noteLogic.UpdateNote(noteViewModel);
            Assert.AreEqual(noteLogic.GetNote(noteRepository.GetNote(noteViewModel.ID)).Name, noteViewModel.Name);
            Assert.AreEqual(noteLogic.GetNote(noteRepository.GetNote(noteViewModel.ID)).Description, noteViewModel.Description);
            noteLogic.RemoveNote(noteViewModel);
        }
    }
}
