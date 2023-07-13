using MySql.Data.MySqlClient;
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
        public MySqlConnection connection;
        private string connectionString = "server=localhost;user=root;database=lagerdatenbank;port=3306;password=";
        
        public MySqlConnection getConnection()
        {
            return this.connection;
        }

        public  bool setConnection()
        {
            try
            {
                //erstellt die Datenbankverbindung
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

        public Artikel gebeArtikelFürArtikelnummerZurück(string input)
        {
            if (this.checkConnection() == false){ return null; }  

            string output = "";
            
            string commandString = "SELECT * FROM artikel WHERE artikelnummer LIKE "+input+ " AND Stückzahl > 0"; 
            MySqlCommand command = new MySqlCommand(commandString, this.connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<string> alleDaten = new List<string>();
            Artikel artikel = new Artikel();

            while (reader.Read() && reader.HasRows)
            {
                artikel.Artikelnummer = reader.GetString(0);
                artikel.Artikelbeschreibung = reader.GetString(1);
                artikel.Preis = reader.GetString(2);
                artikel.Stückzahl = reader.GetInt32(3);
                artikel.Preisaufschlag = reader.GetString(4);
                artikel.LagerId = reader.GetInt16(5);
                artikel.Regal = reader.GetInt32(6);
                artikel.Fach = reader.GetInt32(7);
                artikel.Datum1 = reader.GetString(8);  
            }

            reader.Close();
            return artikel;
        }
        
        public string getStückzahlVonDatenbankFürArtikelnummer(string artikelNummer)
        {
            string output = "";

            //wenn keine Verbindung mit der Datenbank besteht 
            if(this.checkConnection() == false) { return ""; }

            string commandString = "SELECT Stückzahl FROM artikel Where Artikelnummer LIKE " + artikelNummer+"";
            MySqlCommand command = new MySqlCommand(commandString, this.connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read() && reader.HasRows)
            {
                output += reader.GetValue(0);
            }
            reader.Close();
            
            return output;
        }

        public bool setztNeueStückzahlFürArtikelnummer(string artikelnummer, int stückzahl)
        {
            string commandString = "UPDATE artikel SET Stückzahl = " + stückzahl + " Where Artikelnummer LIKE " + artikelnummer;
            MySqlCommand command = new MySqlCommand(commandString, this.connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return false;
        }

        public void closeConnection()
        {
            connection.Close();
        }

    }
}
