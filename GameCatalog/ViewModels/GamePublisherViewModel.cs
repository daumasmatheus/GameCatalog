using System.ComponentModel.DataAnnotations;

namespace GameCatalog.ViewModels
{
    public class GamePublisherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inform the publisher of the game")]
        [MaxLength(255)]
        [Display(Name = "Game Publisher")]
        public string Name { get; set; }
    }
}