﻿using System.Collections.Generic;

namespace GameCatalog.Entities
{
    public class GamePublisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}