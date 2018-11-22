using System.ComponentModel.DataAnnotations;

namespace GameCatalog.ViewModels
{
    public class DeveloperViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inform the developer of the game")]
        [MaxLength(255)]
        [Display(Name = "Game Developer")]
        public string Name { get; set; }
    }
}