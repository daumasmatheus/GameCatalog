using System;

namespace GameCatalog.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual GamePublisher Publisher { get; set; }
    }
}