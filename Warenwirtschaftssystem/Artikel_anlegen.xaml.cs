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
    /// Interaktionslogik für Artikel_anlegen.xaml
    /// </summary>
    public partial class Artikel_anlegen : Page
    {
        public Artikel_anlegen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string artikelnummer = textbox_Artikelnummer.Text;
            string preis = textbox_Preisa.Text;
            string artikelbeschreibung = textbox_Artikelbeschreibung.Text;
            string preisaufschlag = textbox_Preiszuschlag.Text;
            string regal = textbox_Regal.Text;
            string fach = textbox_Regal.Text;
            string stückzahl = textbox_Stückzahl.Text;

            string lagerId = "1";

            Datenbankverbindung verbindung = new Datenbankverbindung();

            verbindung.setConnection();
            verbindung.fügeNeuenArtikelZurDatenbank(artikelnummer, artikelbeschreibung, preis, stückzahl, preisaufschlag, lagerId, regal, fach, false);
            verbindung.closeConnection();
        }
    }
}
