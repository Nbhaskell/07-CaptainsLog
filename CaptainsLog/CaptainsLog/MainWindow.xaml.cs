using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CaptainsLog.Core;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.IO;




namespace CaptainsLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public ObservableCollection<LogEntry> logEntries;
        string blankFile = "C:\\dev\\Origin\\07-CaptainsLog\\data\\blankFile.txt";


        public MainWindow()
        {
            InitializeComponent();

            if (readfile(blankFile).Length < 10)
            {
                logEntries = new ObservableCollection<LogEntry>();
            }
            else
            {
                logEntries = new ObservableCollection<LogEntry>(DeSerJSON(blankFile));
            }

            dataGrid.ItemsSource = logEntries;
        }

        private void _addEntry(object sender, RoutedEventArgs e)
        {
            // collect input

            // validate input

            // add to grid
            string title = "Title";
            string text = "Hey! This is text";
            DateTime date = DateTime.Now;

            // Object
            LogEntry log = new LogEntry();

            log.Title = title;
            log.Text = text;
            log.EntryDate = date;

            logEntries.Add(log);

            log.Id = logEntries.Count + 1;
        }

        // delete an entry
        private void _removeEntry(object sender, RoutedEventArgs e)
        {
            if (logEntries.Count > 0)
            {
                logEntries.Remove(logEntries[logEntries.Count - 1]);
            }
        }

        // store data when program closes without saving
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            writeFile(SerJSON(logEntries), blankFile);
        }

        public string SerJSON(object data)
        {
            string serialized = JsonConvert.SerializeObject(data);
            return serialized;
        }

        public ObservableCollection<LogEntry> DeSerJSON(string x)
        {
            string text = readfile(x);
            ObservableCollection<LogEntry> imported = JsonConvert.DeserializeObject<ObservableCollection<LogEntry>>(text);
            return imported;
        }

        public void writeFile(string logs, string x)
        {
            StreamWriter objWriter;
            objWriter = new System.IO.StreamWriter(x);
            objWriter.Write(logs);
            objWriter.Close();
        }

        public string readfile(string x)
        {
            string jsontext = "";
            System.IO.StreamReader objReader;
            objReader = new System.IO.StreamReader(x);
            do
            {
                jsontext += objReader.ReadLine();
            }
            while (objReader.Peek() != -1);
            objReader.Close();
            return jsontext;
        }
    }
}
        
    
     












