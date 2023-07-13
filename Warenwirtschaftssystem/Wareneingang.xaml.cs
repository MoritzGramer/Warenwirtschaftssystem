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
            //Die artikelNummer initalisiert und mit der Benutzereingabe aus der Textbox deklarasiert
            string artikelNummer = textbox_Artikelnummer.Text;

            //Die Anzahl der eingegangen Stücke wird initialisiert und mit der Benutzereingabe aus der Textbox deklarasiert
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

                //addieren die hinzugefügten Stücke zu den Stückzahlen
                neueStückzahl = aktuelleStückzahl + int.Parse(eingegangeStückzahl_string);
                connection.setztNeueStückzahlFürArtikelnummer(artikelNummer, neueStückzahl);

                connection.closeConnection();
            }

            //eingegeben Stückzahl ist KEINE Zahl
            else
            {
                
            }

            

        }
        public void erstelleFehlermeldung(String text)
        {
            //das Hauptfenster(MainWindow.xaml.cs) wird in eine Variable gespeichert
            Window window = Application.Current.MainWindow;

            //Der Text des Fehlermeldelabes wird gändert
            (window as MainWindow).label_Fehlermeldung.Content = text;
        }



    }
}
