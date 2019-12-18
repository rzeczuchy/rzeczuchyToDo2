using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace rzeczuchyToDo2
{
    class ReaderWriter
    {
        private const string Filepath = "todos.txt";

        public ReaderWriter()
        {
            CreatePlaceholderList();
        }

        public void WriteList(List<ToDo> toDos)
        {
            File.WriteAllText(Filepath, String.Empty);

            using (var streamWriter = new StreamWriter(Filepath, true))
            {
                for (int i = 0; i < toDos.Count(); i++)
                {
                    streamWriter.WriteLine(toDos[i].Label + ',' + (toDos[i].IsChecked ? "d" : ""));
                }
                streamWriter.Close();
            }
        }

        public List<ToDo> ReadListFromFile()
        {
            var list = new List<ToDo>();
            string line = string.Empty;
            using (StreamReader sr = new StreamReader(Filepath))
            {
                int lineID = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (CanParseToDo(line))
                    {
                        list.Add(ParseToDo(line));
                    }
                    lineID++;
                }
            }
            return list;
        }

        private void CreatePlaceholderList()
        {
            if (!File.Exists(Filepath))
            {
                var placeholders = new List<ToDo>()
                {
                    new ToDo("This is an unchecked todo", false),
                    new ToDo("This is a checked todo", true),
                };
                WriteList(placeholders);
            }
        }

        private ToDo ParseToDo(string line)
        {
            string[] substr = line.Split(',');
            return new ToDo(substr[0], substr[1] == "d");
        }

        private bool CanParseToDo(string line)
        {
            if (line.Contains(','))
            {
                string[] substr = line.Split(',');
                return substr[0] != "";
            }
            return false;
        }
    }
}
