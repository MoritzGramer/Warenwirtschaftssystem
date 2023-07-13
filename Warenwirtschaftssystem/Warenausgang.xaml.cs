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
    /// Interaktionslogik für Warenausgang.xaml
    /// </summary>
    public partial class Warenausgang : Page
    {
        public Warenausgang()
        {
            InitializeComponent();
        }

        //Vorgang des Warenausgangs
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Die artikelNummer initalisiert und mit der Benutzereingabe aus der Textbox deklarasiert
            string artikelNummer = textbox_Artikelnummer.Text;

            //Die Anzahl der eingegangen Stücke wird initialisiert und mit der Benutzereingabe aus der Textbox deklarasiert
            string ausgehendeStückzahl_String = textbox_Stückzahl.Text;

            int aktuelleStückzahl = 0;

          

            bool isNumeric = int.TryParse(ausgehendeStückzahl_String, out int num);

            //die eingegbene Stückzahl ist keine Zahl
            if (isNumeric== false)
            {
                erstelleFehlermeldung("Bitte geben sie eine gültige Zahl als Stückzahl ein!");
            }
            else{
                Datenbankverbindung connection = new Datenbankverbindung();
                connection.setConnection();

                //die aktuelle Stückzahl des Artikels wird abgefragt und in einer Variable gespeichert
                aktuelleStückzahl = int.Parse(connection.getStückzahlVonDatenbankFürArtikelnummer(artikelNummer));

                //die Anzahl der ausgehenden Artikel ist kleiner oder gleich groß wie die Anzahl der verfügbaren Artikel
                if(aktuelleStückzahl - int.Parse(ausgehendeStückzahl_String) > 0)
                {
                    //abziehen der Stückzahlen
                    int neueStückzahl = aktuelleStückzahl - int.Parse(ausgehendeStückzahl_String);

                    //updaten der Stückzahl in der Datenbank
                    connection.setztNeueStückzahlFürArtikelnummer(artikelNummer, neueStückzahl);
                }
                //Es wird versucht mehr Waren rauszugeben, als im Lager sind
                else
                {
                    //Fehlermeldung anzeigen
                    erstelleFehlermeldung("So viele Artikel sind nicht auf Lager!");
                }
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
