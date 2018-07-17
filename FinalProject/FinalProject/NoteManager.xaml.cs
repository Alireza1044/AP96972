using Business;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for NoteManager.xaml
    /// </summary>
    public partial class NoteManager : Window
    {
        public bool Editing = false;
        NoteRepository noteRepository = new NoteRepository();
        NoteViewModel EditingNote = new NoteViewModel();
        NoteLogic noteLogic = new NoteLogic();
        MainWindow mw;

        public NoteManager()
        {
            InitializeComponent();
			WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
		}

        public NoteManager(string ID)
        {
            InitializeComponent();
            EditingNote = noteLogic.GetNote(noteRepository.GetNote(ID));
            //EditingNote.Name = NoteTitleTextBox.Text;
            //EditingNote.Description = NoteDescriptionTextBox.Text;
            NoteDescriptionTextBox.Text = EditingNote.Description;
            NoteTitleTextBox.Text = EditingNote.Name;
            Editing = true;
        }

        private void BtnDelEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Editing)
            {
                noteLogic.RemoveNote(EditingNote);
                mw = new MainWindow();
                Close();
            }
            else
            {
                mw = new MainWindow();
                Close();
            }
            mw.ShowDialog();
        }

        private void AddBtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Editing)
            {
                EditingNote.Name = NoteTitleTextBox.Text;
                EditingNote.Description = NoteDescriptionTextBox.Text;
                noteLogic.UpdateNote(EditingNote);
            }
            else
            {
                EditingNote.Name = NoteTitleTextBox.Text;
                EditingNote.Description = NoteDescriptionTextBox.Text;
                EditingNote.ID = DateTime.Now.ToString();
                noteLogic.NewNote(EditingNote);
            }
            mw = new MainWindow();
            Close();
            mw.ShowDialog();
        }

        private void NoteTitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NoteDescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ColorChange_Click(object sender, RoutedEventArgs e)
        {
            ColorChange cg = new ColorChange();
            this.Hide();
            cg.ShowDialog();
        }
    }
}
