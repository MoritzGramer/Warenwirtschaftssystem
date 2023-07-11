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

namespace Warenwirtschaftssystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Warenanzeige warenAnzeige = new Warenanzeige();

        public MainWindow()
        {
            InitializeComponent();
            button_Artikelanzeigen.Background = Brushes.Gray;
        }

        private void geheZuWareneingang(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Aufnehmen von Waren
        }

        private void geheZuWarenausgang(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das managen von Waren, die das Lager verlassen
        }

        private void zeigeWarenAn(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Einsehen der Artikel im Lager
            warenAnzeige.Owner = this;
            warenAnzeige.Show();
        }

        private void legeNeuenArtikelAn(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Anlegen von neuen Artikeln

        }
    }
}
