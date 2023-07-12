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
    
    public partial class Artikelanzeige : Page
    {
        public Artikelanzeige()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string artikelnummer = eingabe_Artikelnummer.Text;

            Datenbankverbindung connection = new Datenbankverbindung();
            connection.setConnection();
            Artikel artikel = connection.gebeArtikelFürArtikelnummerZurück(artikelnummer);
            labelArtikelname.Content = "Artikelnummer: " + artikel.Artikelnummer;
            labelArtikelbeschreibung.Content = "Artikelbeschreibung: " + artikel.Artikelbeschreibung;
            labelPreis.Content = "Artikelpreis: " + artikel.Preis;
            labelPreiszuschlag.Content = "Preisaufschlag: " + artikel.Preisaufschlag;
            labelFach.Content = "Fach: " + artikel.Fach;
            labelRegal.Content = "Regal: "+artikel.Regal;
           

            connection.closeConnection();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
