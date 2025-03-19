using System.ComponentModel.DataAnnotations;

namespace TakenlijstManager.Models
{
    public class TaakModel
    {
        const string LENGTH_RANGE_ERROR = "Naam mag van 3 tot 40 karakters bevatten";
        public int Id { get; set; }
        [Required()]
        [MinLength(3)]
        [MaxLength(40)]
        public string Naam { get; set; }

        public int Omvang { get; set; }
        [Range(0,1)]
        public int Prioriteit { get; set; }

        public TaakModel(int id, string naam, int omvang, int prioriteit)
        {
            Id = id;
            Naam = naam;
            Omvang = omvang;
            Prioriteit = prioriteit;
        }

    }
}
