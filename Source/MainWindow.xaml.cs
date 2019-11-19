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
        private Stack<ToDo> todos;

        public MainWindow()
        {
            InitializeComponent();

            todos = new Stack<ToDo>();
            todos.Push(new ToDo("this is a checked ToDo", true));
            todos.Push(new ToDo("this is an unchecked ToDo", false));
            for (int i = 0; i < 100; i++)
            {
                todos.Push(new ToDo("this is a checked ToDo", true));
                todos.Push(new ToDo("this is an unchecked ToDo", false));
            }
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
                todos.Push(new ToDo(NewToDoTextBox.Text, false));
                ToDoListView.Items.Refresh();
            }
            NewToDoTextBox.Text = "";
        }
    }
}
