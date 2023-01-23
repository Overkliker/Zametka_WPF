using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Zametka_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MakeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionBox.Text != "" && NameZamBox.Text != "")
            {
                var des = JsonSer.Des();
                if (des.ContainsKey(datePicker1.SelectedDate.ToString()) && des.Keys != null)
                {
                    Note newNote = new Note();
                    newNote.descrption = DescriptionBox.Text;
                    newNote.name = NameZamBox.Text;
                    newNote.dateTime = datePicker1.SelectedDate.ToString();
                    des[datePicker1.SelectedDate.ToString()].Add(newNote);
                }
                else
                {
                    Note newNote = new Note();
                    newNote.descrption = DescriptionBox.Text;
                    newNote.name = NameZamBox.Text;
                    newNote.dateTime = datePicker1.SelectedDate.ToString();

                    List<Note> newDate = new List<Note>();
                    newDate.Add(newNote);
                    des.Add(newNote.dateTime, newDate);
                }

                JsonSer.Ser(des);
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zametki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = Zametki.SelectedIndex;
            string date = datePicker1.SelectedDate.ToString();
            Note des = JsonSer.Des()[date][ind];

            DescriptionBox.Text = des.descrption;
            NameZamBox.Text = des.name;


        }
    }
}
