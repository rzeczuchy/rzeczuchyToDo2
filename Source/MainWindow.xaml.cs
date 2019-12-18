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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rzeczuchyToDo2
{
    public partial class MainWindow : Window
    {
        private List<ToDo> todos;
        private ReaderWriter readerWriter;

        public MainWindow()
        {
            InitializeComponent();
            readerWriter = new ReaderWriter();

            todos = readerWriter.ReadListFromFile();
            NewToDoTextBox.MaxLength = ToDo.MaxNameLenght;
            
            DisplayToDoList();
        }

        private void DisplayToDoList()
        {
            if (todos != null)
            {
                ToDoListView.ItemsSource = todos;
            }
        }

        private void AddToDoButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewToDoTextBox.Text != "")
            {
                todos.Add(new ToDo(NewToDoTextBox.Text, false));
                ToDoListView.Items.Refresh();
                readerWriter.WriteList(todos);
                NewToDoTextBox.Text = "";
                Border border = (Border)VisualTreeHelper.GetChild(ToDoListView, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ToDo todo)
            {
                todos.Remove(todo);
                ToDoListView.Items.Refresh();
                readerWriter.WriteList(todos);
            }
        }

        private void ToDoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListView.Items.Refresh();
            readerWriter.WriteList(todos);
        }

        private void NewToDoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                AddToDoButton_Click(this, new RoutedEventArgs());
            }
        }

        private void LabelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            readerWriter.WriteList(todos);
        }

        private void LabelBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Return || e.Key == Key.Enter) && sender is TextBox textbox)
            {
                NewToDoTextBox.Focus();
            }
        }
    }
}
