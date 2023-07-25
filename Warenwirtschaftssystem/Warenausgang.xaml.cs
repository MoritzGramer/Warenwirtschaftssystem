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

            //Die artikelNummer initalisiert und mit der Benutzereingabe aus der Textbox deklariert
            string artikelNummer = textbox_Artikelnummer.Text;

            //Die Anzahl der eingegangen Stücke wird initialisiert und mit der Benutzereingabe aus der Textbox deklariert
            string ausgehendeStückzahl_String = textbox_Stückzahl.Text;

            int aktuelleStückzahl = 0;

            //Quelle https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number visited: 12.07.23
            bool isNumeric = int.TryParse(ausgehendeStückzahl_String, out int num);
            //Quelle Ende

            Feedback feedback = new Feedback();

            //die eingegbene Stückzahl ist keine Zahl
            if (isNumeric== false)
            {
                feedback.erstelleFehlermeldung("Bitte geben sie eine gültige Zahl als Stückzahl ein!");
            }
            else{

                //Instanz der Klasse Datenbankverbindung wird erstellt
                Datenbankverbindung connection = new Datenbankverbindung();

                if (connection.setConnection())
                {
                    //die aktuelle Stückzahl des Artikels wird abgefragt und in einer Variable gespeichert
                    aktuelleStückzahl = int.Parse(connection.getLagerbestandVonDatenbankFürArtikelnummer(artikelNummer));

                    //die Anzahl der ausgehenden Artikel ist kleiner oder gleich groß wie die Anzahl der verfügbaren Artikel
                    if (aktuelleStückzahl - int.Parse(ausgehendeStückzahl_String) > 0)
                    {
                        //abziehen der Stückzahlen
                        int neueStückzahl = aktuelleStückzahl - int.Parse(ausgehendeStückzahl_String);

                        //updaten der Stückzahl in der Datenbank
                        connection.setztNeuenLagerbestandFürArtikelnummer(artikelNummer, neueStückzahl);
                        
                    }
                    //Es wird versucht mehr Waren rauszugeben, als im Lager sind
                    else
                    {
                        //Fehlermeldung anzeigen
                        feedback.erstelleFehlermeldung("Vorgang abgebrochen. Der Lagerbestand des Artikels mit der Artikelnummer " + artikelNummer + " beträgt nur " + aktuelleStückzahl +"!");
                    }
                }
                else
                {
                    feedback.erstelleFehlermeldung("Es konnte keine Datenbankverbindung aufgebaut werden!");
                }
            }
        }
    }
}
