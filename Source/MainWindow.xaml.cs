﻿using System;
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
    }
}
