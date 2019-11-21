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
    class ToDo
    {
        public const int MaxNameLenght = 50;
        private readonly SolidColorBrush active;
        private readonly SolidColorBrush inactive;

        public ToDo(string name, bool isChecked)
        {
            Name = name.Length > MaxNameLenght ? name.Substring(0, MaxNameLenght) : name;
            IsChecked = isChecked;
            active = new SolidColorBrush() { Color = Colors.WhiteSmoke };
            inactive = new SolidColorBrush() { Color = Colors.LightSlateGray };
        }

        public string Name { get; private set; }
        public bool IsChecked { get; set; }
        public SolidColorBrush TextColor { get { return IsChecked ? inactive : active; } }
        public TextDecorationCollection Decorations { get { return IsChecked ? TextDecorations.Strikethrough : null; } }

        public override string ToString()
        {
            return Name;
        }
    }
}
