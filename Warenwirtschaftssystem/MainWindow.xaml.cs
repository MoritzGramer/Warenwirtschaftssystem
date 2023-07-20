using MySql.Data.MySqlClient;
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

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            frame_Content.Content = new Artikelanzeige();
            //button_Artikelanzeigen.Background = Brushes.Gray;

        }

        //Läd eine Unterseite in den Content Frame der Hauptseite
        private void geheZuWareneingang(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Aufnehmen von Waren
            frame_Content.Content = new Wareneingang();
            label_Fehlermeldung.Content = "";
        }

        private void geheZuWarenausgang(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das managen von Waren, die das Lager verlassen
            frame_Content.Content = new Warenausgang();
            label_Fehlermeldung.Content = "";
        }

        private void zeigeWarenAn(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Einsehen der Artikel im Lager
            frame_Content.Content = new Artikelanzeige();
            label_Fehlermeldung.Content = "";

        }

        private void legeNeuenArtikelAn(object sender, RoutedEventArgs e)
        {
            //Weiterleitung zur Seite für das Anlegen von neuen Artikeln
            frame_Content.Content = new Artikel_anlegen();
            label_Fehlermeldung.Content = "";
        }

        private void fehlerMeldung(String text)
        {

        }
    
    }
}