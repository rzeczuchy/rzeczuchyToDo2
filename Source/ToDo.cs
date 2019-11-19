using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rzeczuchyToDo2
{
    class ToDo
    {
        public const int MaxNameLenght = 50;

        public ToDo(string name, bool isChecked)
        {
            Name = name.Length > MaxNameLenght ? name.Substring(0, MaxNameLenght) : name;
            IsChecked = isChecked;
        }

        public string Name { get; private set; }
        public bool IsChecked { get; private set; }

        public void CheckUncheck()
        {
            IsChecked = !IsChecked;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
