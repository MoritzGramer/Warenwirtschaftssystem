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

            //erstelle 
            Feedback feedback = new Feedback();

            //eingegeben Stückzahl ist eine Zahl
            if (isNumeric)
            { 

                Datenbankverbindung connection = new Datenbankverbindung();
                if (connection.setConnection())
                {
                    string lagerStückzahl_string = connection.getLagerbestandVonDatenbankFürArtikelnummer(artikelNummer);
                    if (lagerStückzahl_string != "")
                    {
                        aktuelleStückzahl = int.Parse(lagerStückzahl_string);

                        //addieren die hinzugefügten Stücke zu den Stückzahlen
                        neueStückzahl = aktuelleStückzahl + int.Parse(eingegangeStückzahl_string);
                        connection.setztNeuenLagerbestandFürArtikelnummer(artikelNummer, neueStückzahl);
                        feedback.erstelleErfolgsmeldung("Aktion erfolgreich!");
                    }
                    else
                    {
                        feedback.erstelleFehlermeldung("Keine gültige Artikelnummer eingegeben");
                    }

                    connection.closeConnection();
                }
                else
                {
                    feedback.erstelleFehlermeldung("Es konnte keine Datenbankverbindung aufgebaut werden!");
                }

                
            }

            //eingegeben Stückzahl ist KEINE Zahl
            else
            {
                feedback.erstelleFehlermeldung("Bitte geben sie eine Zahl als Stückzahl ein");
            }
        }
    }
}
