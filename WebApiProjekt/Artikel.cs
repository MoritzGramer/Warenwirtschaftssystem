namespace Warenwirtschaftssystem
{
    public class Artikel
    {
        
        public string Artikelnummer { get; set; }
        public string Artikelbeschreibung { get; set; }
        public int Lagerbestand { get; set; }
        public int Preisaufschlag { get; set; }
        public int Regal { get; set; }
        public int Fach { get; set; }
        public string Reserviert { get; set; }

    }
}