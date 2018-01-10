using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Test1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private int caretIndex;

        public MainWindow() {
            InitializeComponent();
            StringBuilder test2 = new StringBuilder();
            foreach (var i in Enumerable.Range(1, 13)) { // Change the end limit to 5 and it will work just fine
                test2.Append(Environment.NewLine + "WTF! " + i);
            }

            Box.Text = test2.ToString();
            Box.ScrollToLine(Box.LineCount - 1);
            Box.CaretIndex = Box.Text.Length;

            caretIndex = Box.CaretIndex;
        }

        private void Box_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var lineIndex = Box.GetLineIndexFromCharacterIndex(caretIndex);
            var commandsText = lineIndex >= 0 && lineIndex < Box.LineCount ?
                Box.GetLineText(lineIndex) : "";
            MessageBox.Show($"Asking line number : {lineIndex} . Value returned : {commandsText}");
        }
    }
}
