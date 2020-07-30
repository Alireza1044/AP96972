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
        Note note = new Note();
        NoteViewModel noteViewModel = new NoteViewModel();
        string name = "the test title";
        string description = "this is the test description!";
        static string time = "7/15/2018 6:15:17 PM";

        [TestMethod()]
        public void NewNoteTest()
        {
            noteLogic.NewNote(noteViewModel);
            Assert.IsTrue(noteRepository.NotesList().Contains(noteRepository.GetNote(noteViewModel.ID)));
            noteLogic.RemoveNote(noteViewModel);
        }



    }
}