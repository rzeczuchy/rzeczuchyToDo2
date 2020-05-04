using System.Windows;
using System.Windows.Media;

namespace rzeczuchyToDo2
{
    class ToDo
    {
        public const int MaxNameLenght = 50;
        private readonly SolidColorBrush active;
        private readonly SolidColorBrush inactive;

        public ToDo(string name, bool isChecked)
        {
            Label = name.Length > MaxNameLenght ? name.Substring(0, MaxNameLenght) : name;
            IsChecked = isChecked;
            active = new SolidColorBrush() { Color = Colors.WhiteSmoke };
            inactive = new SolidColorBrush() { Color = Colors.LightSlateGray };
        }

        public string Label { get; set; }
        public bool IsChecked { get; set; }
        public SolidColorBrush TextColor { get { return IsChecked ? inactive : active; } }
        public TextDecorationCollection Decorations { get { return IsChecked ? TextDecorations.Strikethrough : null; } }
    }
}
