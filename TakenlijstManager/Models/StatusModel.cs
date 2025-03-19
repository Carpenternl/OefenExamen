using System.ComponentModel.DataAnnotations;

namespace TakenlijstManager.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "van 3 tot 40 karakters")]
        [MaxLength(40,ErrorMessage ="van 3 tot 40 karakters")]
        public string Naam { get; set; }
        public int VolgendeStatus { get; set; }
    }
}
