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
            //artikelnummer wird initialisiert und mit Benutzereingabe deklarasiert
            string artikelnummer = eingabe_Artikelnummer.Text;

            //Datenbankverbindung wird aufgebaut
            Datenbankverbindung connection = new Datenbankverbindung();

            //Klasse Feedback wird initialisiert
            Feedback feedback = new Feedback();


            //die Funktion gibt bei erfolgreichem Aufbau der Datenbankverbindung true zürück
            if (connection.setConnection())
            {
                //Objekt der Klasse Artikel wird angelegt und mit Werten aus der Datenbank befüllt
                Artikel artikel = connection.gebeArtikelFürArtikelnummerZurück(artikelnummer);

                //es wurde ein Artikel mit der eingegeben Artikelnummer gefunden und zurückgegeben
                if (artikel != null)
                {
                    labelArtikelname.Content = "Artikelnummer: " + artikel.Artikelnummer;
                    labelArtikelbeschreibung.Content = "Artikelbeschreibung: " + artikel.Artikelbeschreibung;
                    labelPreis.Content = "Artikelpreis: " + artikel.Preis;
                    labelPreiszuschlag.Content = "Preisaufschlag: " + artikel.Preisaufschlag;
                    labelFach.Content = "Fach: " + artikel.Fach;
                    labelRegal.Content = "Regal: " + artikel.Regal;
                    labelReserviert.Content = "Reserviert: "+ artikel.Reserviert;   

                    feedback.erstelleErfolgsmeldung("Ausführen Erfolgreich!");
                }

                //es wurde kein Artikel mit der eingegeben Artikelnummer gefunden
                else
                {
                    feedback.erstelleFehlermeldung("Kein Artikel mit dieser Artikelnummer gefunden");
                }
                //Datenbankverbindung wird geschlossen
                connection.closeConnection();
            }

            //es konnte keine Verbindung zur Datenbank aufgestellt werden
            else
            {
                feedback.erstelleFehlermeldung("Es konnte keine Datenbankverbindung aufgebaut werden!");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
