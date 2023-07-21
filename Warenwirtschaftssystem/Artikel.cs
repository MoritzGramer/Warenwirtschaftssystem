using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warenwirtschaftssystem
{
    internal class Artikel
    {

        //Klassenattribute
        private string artikelnummer;
        private string artikelbeschreibung;
        private string preis;
        private int stückzahl;
        private string preisaufschlag;
        private int lagerId;
        private int regal;
        private int fach;
        private string Datum;
        private string reserviert;


        public Artikel(string artikelnummer, string artikelbeschreibung, string preis, int stückzahl, string preisaufschlag, int lagerId, int regal, int fach, string datum, string reserviert)
        {
            this.Artikelnummer = artikelnummer;
            this.Artikelbeschreibung = artikelbeschreibung;
            this.Preis = preis;
            this.Stückzahl = stückzahl;
            this.Preisaufschlag = preisaufschlag;
            this.LagerId = lagerId;
            this.Regal = regal;
            this.Fach = fach;
            this.Datum1 = datum;
            this.Reserviert = reserviert;
        }
        public Artikel()
        {

        }

        //getter und sett für alle Klassenattribute
        public string Artikelnummer { get => artikelnummer; set => artikelnummer = value; }
        public string Artikelbeschreibung { get => artikelbeschreibung; set => artikelbeschreibung = value; }
        public string Preis { get => preis; set => preis = value; }
        public int Stückzahl { get => stückzahl; set => stückzahl = value; }
        public string Preisaufschlag { get => preisaufschlag; set => preisaufschlag = value; }
        public int LagerId { get => lagerId; set => lagerId = value; }
        public int Regal { get => regal; set => regal = value; }
        public int Fach { get => fach; set => fach = value; }
        public string Datum1 { get => Datum; set => Datum = value; }
        public string Reserviert { get => reserviert; set => reserviert = value; }
    }
}
