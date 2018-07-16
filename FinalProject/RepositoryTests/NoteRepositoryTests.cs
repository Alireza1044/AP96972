using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class NoteRepositoryTests
    {
        NoteRepository noteRepository = new NoteRepository();
        static string name = "the name";
        static string description = "the test description!";
        static string id = "7/16/2018 11:30:48 AM";
        Note note = new Note(name, description, id);

        [TestMethod()]
        public void NewNoteTest()
        {
            noteRepository.NewNote(note);
            Assert.IsTrue(noteRepository.NotesList().Contains(note));
            noteRepository.RemoveNote(note);
        }

        [TestMethod()]
        public void RemoveNoteTest()
        {
            noteRepository.NewNote(note);
            noteRepository.RemoveNote(note);
            Assert.IsFalse(noteRepository.NotesList().Contains(note));
        }

        [TestMethod()]
        public void GetNoteTest()
        {
            noteRepository.NewNote(note);
            Assert.AreEqual(noteRepository.GetNote(note.ID), note);
            noteRepository.RemoveNote(note);
        }

        [TestMethod()]
        public void UpdateNoteTest()
        {
            noteRepository.NewNote(note);
            note.Name = "Worldcup Final";
            note.Description = "Worldcup final starts at 11.30 PM";
            noteRepository.UpdateNote(note);
            Assert.AreEqual(noteRepository.GetNote(note.ID).Name, note.Name);
            Assert.AreEqual(noteRepository.GetNote(note.ID).Description, note.Description);
            noteRepository.RemoveNote(note);
        }

        [TestMethod()]
        public void GetNoteListTest()
        {
            var noteList = noteRepository.NotesList();
            noteRepository.NewNote(note);
            Assert.AreNotEqual(noteRepository.NotesList(), noteList);
            Assert.IsTrue(noteRepository.NotesList().Contains(note));
            noteRepository.RemoveNote(note);
        }
    }
}