using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Warenwirtschaftssystem
{
    internal class Feedback
    {
        public Feedback()
        {

        }

        private void erstelleRückmeldung(String text, SolidColorBrush brush)
        {
            //das Hauptfenster(MainWindow.xaml.cs) wird in eine Variable gespeichert
            Window window = Application.Current.MainWindow;

            //setzte die Schriftfarbe des labels auf rot
            (window as MainWindow).label_Fehlermeldung.Foreground = brush;  // named colors

            //Der Text des Fehlermeldelabes wird gändert
            (window as MainWindow).label_Fehlermeldung.Content = text;
        }

        public void erstelleFehlermeldung(String text)
        {
            erstelleRückmeldung(text, new SolidColorBrush(Colors.Red));
        }

        public void erstelleErfolgsmeldung(String text)
        {
            erstelleRückmeldung(text, new SolidColorBrush(Colors.Green));
        }
    }
}
