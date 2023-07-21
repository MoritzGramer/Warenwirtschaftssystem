using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Warenwirtschaftssystem
{
    class Datenbankverbindung
    {
        //Verbindung zur SQL Datenbank in einer Variable
        private  MySqlConnection connection;

        //Verbindungsstring, der alle Informationen erhält, um die Datenbankverbindung herzustellen
        private string connectionString = "server=localhost;user=root;database=lagerdatenbank;port=3306;password=";
        

        //getter, der die Verbindung zurückgibt
        public MySqlConnection getConnection()
        {
            //gibt die Datenbankverbindung zurück
            return this.connection;
        }

        //Mehtode, welche versucht eine Datenbankverbindung aufzubauen
        public  bool setConnection()
        {
            try
            {
                //erstellt die Datenbankverbindung mit den Informationen aus dem connectionString
                this.connection = new MySqlConnection(connectionString);

                //öffnet die Verbindung
                this.connection.Open();

                //gibt wahr zurück, wenn die Verbindung aufgebaut wurde
                return true;
            }
            catch (Exception e)
            {
                
            }
            //gibt falls zurück, falls keine Datenbankverbindung aufgebaut werden konnte
            return false;
        }

        //gibt den Status der Datenbankverbindung zurück
        public bool checkConnection()
        {
            //bei Rückgabewert 'true' besteht eine aktive Verbindung zur Datenbank
            if (this.connection != null) { return true; }

            //bei Rückgabewert 'false' besteht keine aktive Verbindung zur Datenbank
            return false;
        }

        //Methode, welche für die übergebene Artikelnummer die Artikelinformationen als Objekt der Klasse Artikel zurückgibt
        public Artikel gebeArtikelFürArtikelnummerZurück(string input)
        {
            //eine neues Objekt der Klasse Artikel wird erstellt
            Artikel artikel = new Artikel();

            //wenn keine Datenbankverbindung besteht wird ein leerer Artikel zurück gesendet
            if (this.checkConnection() == false){ return artikel; }  
            
            //SQL Befehl, der den Lagerbestand eines Artikels anzeigt
            //Die Lagerbestand des Artikels muss größer 0 sein
            string commandString = "SELECT * FROM artikel " +
                "WHERE artikelnummer LIKE "+input+ " AND Lagerbestand > 0"; 

            //der string befel wird in einen SQL Command umgewandelt
            MySqlCommand command = new MySqlCommand(commandString, this.connection);

            //der SQl Befehl wird ausgeführt und die Ergebnisse werden in dem Object reader gespeichert
            MySqlDataReader reader = command.ExecuteReader();

            //While Schleife, die durch die Informationen im reader iteriert
            while (reader.Read() && reader.HasRows)
            {
                //Die Artikelinformationen werden aus der Datenbank ausgelesen
                //und in einem Objekt der Klasse Artikel gespeichert
                artikel.Artikelnummer = reader.GetString(0);
                artikel.Artikelbeschreibung = reader.GetString(1);
                artikel.Preis = reader.GetString(2);
                artikel.Stückzahl = reader.GetInt32(3);
                artikel.Preisaufschlag = reader.GetString(4);
                artikel.LagerId = reader.GetInt16(5);
                artikel.Regal = reader.GetInt32(6);
                artikel.Fach = reader.GetInt32(7);
                artikel.Datum1 = reader.GetString(8);  
                artikel.Reserviert = reader.GetString(9);
            }
            //der Daten
            reader.Close();

            //das Objekt artikel mit den Artikelinformationen wird zurückgegeben
            return artikel;
        }

        //Methode, welche für die übergeben Artikelnummer die Stückzahl des Artikels anzeigt
        public string getLagerbestandVonDatenbankFürArtikelnummer(string artikelNummer)
        {
            string output = "";

            //wenn keine Verbindung mit der Datenbank besteht 
            if (this.checkConnection() == false) {
                output = "";
            }
            else
            {
                //wenn die eingegben Artikelnummer nicht der String 'Artikelnummer'
                if (!artikelNummer.Equals("Artikelnummer"))
                {
                    //SQL Befehl, der sich für eine bestimmte Artikelnummer
                    //den Lagerbestand von der Datenbank holt
                    string commandString = "SELECT Lagerbestand FROM artikel" +
                        " Where Artikelnummer LIKE " + artikelNummer + "";

                    //SQl string Befehl wird umgewandelt in ein MySQLCommand
                    MySqlCommand command = new MySqlCommand(commandString, this.connection);

                    //der SQL Befehl wird ausgeführt und die Informationen werden
                    MySqlDataReader reader = command.ExecuteReader();

                    //solange sich weitere Informationen in dem Objekt reader befinden
                    while (reader.Read() && reader.HasRows)
                    {
                        //die Stückzahl wird zu dem string output addiert
                        output += reader.GetValue(0);
                    }
                    //der reader wird geschlossen
                    reader.Close();
                }
           
            }
            //der Ergebniss String wird zurückgegeben
            return output;
        }


        //Methode, welche für die übergebene Artikelnummer und Stückzahl die Stückzahl des Artikels in der Datenbank ändert
        public bool setztNeuenLagerbestandFürArtikelnummer(string artikelnummer, int stückzahl)
        {
            //String, SQL Befehl, welcher den Lagerbestand in der Datenbank
            //für eine bestimmte Artikelnummer aktualisiert
            string commandString = "UPDATE artikel SET Lagerbestand = " + stückzahl 
                + " Where Artikelnummer LIKE " + artikelnummer;


            MySqlCommand command = new MySqlCommand(commandString, this.connection);

            //der SQL Befehl wird ausgeführt
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return false;
        }


        //Methode, welche ein neuen Artikel mit den übergebenen Informationen erstellt
        public bool fügeNeuenArtikelZurDatenbank(string artikelNummer, string artikelbeschreibung, string preis, string stückzahl, string preisaufschlag, string lager_id, string regal, string fach, string reserviert)
        {
            //SQl Befehl, welcher einen neuen Eintrag in der Tabelle Artikel erstellt.
            string commandString = "INSERT INTO artikel(Artikelnummer, Artikelbeschreibung," +
                "Lagerbestand, preis, Preisaufschlag, Lager_id, regal, fach, Eingangsatum," +
                " reserviert)" +
                " VALUES( "+artikelNummer+ ", '"+ artikelbeschreibung + "', " + stückzahl +
                ", " + preis + ", " + preisaufschlag + ", " + lager_id + ", " + regal +
                ", " + fach + ", CURRENT_TIMESTAMP" + ", '" + reserviert+"')";

            MySqlCommand command = new MySqlCommand(commandString, this.connection);
            try
            {
                //der reader führt den Befehl aus
                MySqlDataReader reader = command.ExecuteReader();

                //der Befehl wurde erfolgreich durchgeführt und true wird zurückgegeben
                return true;
            }
            catch (Exception e)
            {

            }

            //der Vorgang lief nicht erfolgreich ab und false wird zurückgegeben
            return false;
        }

        //Methode, welche die Verbindug zur Datenbank beendet
        public void closeConnection()
        {
            //Die Datenbankverbindung wird geschlossen
            connection.Close();
        }
    }
}
