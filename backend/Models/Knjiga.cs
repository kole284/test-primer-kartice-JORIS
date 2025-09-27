using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Knjiga
    {
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Autor { get; set; }
        public string Zanr { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Opis { get; set; }
        public string SlikaUrl { get; set; }
        public int BrojStranica { get; set; }
        public string Jezik { get; set; }
        public string Izdavac { get; set; }
        public decimal Cena { get; set; }
        public int KolicinaNaStanju { get; set; }
    }
}