using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

namespace rzeczuchyToDo2
{
    class ReaderWriter
    {
        private const string Filepath = "todos.xml";

        public ReaderWriter()
        {
            CreatePlaceholderList();
        }

        public void SaveToDos(List<ToDo> toDos)
        {
            using (XmlWriter writer = XmlWriter.Create(Filepath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ListOfToDos");

                foreach (ToDo todo in toDos)
                {
                    SaveToDo(todo, writer);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public List<ToDo> LoadToDos()
        {
            var list = new List<ToDo>();

            using (XmlReader reader = XmlReader.Create(Filepath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        ToDo todo = LoadToDo(reader);

                        if (todo != null)
                        {
                            list.Add(todo);
                        }
                    }
                }
            }
            
            return list;
        }

        private ToDo LoadToDo(XmlReader reader)
        {
            string label = reader["Label"];
            if (label != null && bool.TryParse(reader["Done"], out bool done))
            {
                return new ToDo(label, done);
            }
            return null;
        }

        private void SaveToDo(ToDo todo, XmlWriter writer)
        {
            if (todo != null && todo.Label != null)
            {
                writer.WriteStartElement("ToDo");
                writer.WriteAttributeString("Label", todo.Label);
                writer.WriteAttributeString("Done", todo.IsDone.ToString());
                writer.WriteEndElement();
            }
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
                SaveToDos(placeholders);
            }
        }
    }
}
