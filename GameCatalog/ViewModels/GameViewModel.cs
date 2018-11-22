using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inform the title of the game.")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Inform the description of the game")]
        [MaxLength(25555)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Inform the release date of the game")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public virtual DeveloperViewModel Developer { get; set; }
        public virtual GamePublisherViewModel Publisher { get; set; }
    }
}