using System.ComponentModel.DataAnnotations;

namespace CrazyMusicians.Models
{
    public class Musician
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Profession { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string FunFact { get; set; } = string.Empty;
    }
}
