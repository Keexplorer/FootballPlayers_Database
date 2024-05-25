using System.ComponentModel.DataAnnotations;

namespace SD_Lab2.Models
{
    public class PlayerDto
    {
        [Required]
        public int Uniform_Number { get; set; } = 0;
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Surname { get; set; } = "";
        [Required] 
        public int Age { get; set; } = 0;
        [Required]
        public string Country { get; set; } = "";
    }
}
