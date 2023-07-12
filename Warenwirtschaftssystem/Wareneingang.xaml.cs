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
    /// Interaktionslogik für Wareneingang.xaml
    /// </summary>
    public partial class Wareneingang : Page
    {
        public Wareneingang()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string artikelNummer = textbox_Artikelnummer.Text;
            string eingegangeStückzahl_string = textbox_Stückzahl.Text;
            int aktuelleStückzahl = 0;
            int neueStückzahl;

            //Quelle https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number visited: 12.07.23
            bool isNumeric = int.TryParse(eingegangeStückzahl_string, out int num);
            //Quelle Ende

            //eingegeben Stückzahl ist eine Zahl
            if (isNumeric)
            { 

                Datenbankverbindung connection = new Datenbankverbindung();
                connection.setConnection();
                aktuelleStückzahl = int.Parse(connection.getStückzahlVonDatenbankFürArtikelnummer(artikelNummer));

                //addieren die Stückzahlen
                neueStückzahl = aktuelleStückzahl + int.Parse(eingegangeStückzahl_string);
                connection.setztNeueStückzahlFürArtikelnummer(artikelNummer, neueStückzahl);

                connection.closeConnection();
            }

            //eingegeben Stückzahl ist KEINE Zahl
            else
            {

            }

            

        }
    }
}
