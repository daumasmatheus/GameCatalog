using System;

namespace GameCatalog.ViewModels
{
    public class GameEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
    }
}