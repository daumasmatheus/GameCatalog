using GameCatalog.App_Start;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;
using GameCatalog.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GameCatalog.Controllers.Api
{
    public class GameController : ApiController
    {
        private IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        [Route("api/games")]
        public IHttpActionResult GetAllGames()
        {
            var mapper = MappingProfile.GetMapper();

            var games = mapper.Map<IEnumerable<Game>,
                                   IEnumerable<GameViewModel>>(_repository.Get().ToList());

            return Ok(games);
        }

        [Route("api/games/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var mapper = MappingProfile.GetMapper();

            var game = mapper.Map<Game, GameViewModel>(_repository.Find(id));

            return Ok(game);
        }

        [Route("api/games")]
        [HttpPost]
        public IHttpActionResult AddNewGame(Game game)
        {
            _repository.Add(game);
            _repository.SaveChanges();
            return Ok();
        }       

        [Route("api/games/edit/")]
        [HttpPut]
        public IHttpActionResult EditGame(GameEditViewModel gameEditViewModel)
        {
            var mapper = MappingProfile.GetMapper();

            if (gameEditViewModel == null)
            {
                return NotFound();
            }

            var gameDomain = new Game {
                Id = gameEditViewModel.Id,
                Title = gameEditViewModel.Title,
                Description = gameEditViewModel.Description,
                ReleaseDate = gameEditViewModel.ReleaseDate,
                DeveloperId = gameEditViewModel.DeveloperId,
                PublisherId = gameEditViewModel.PublisherId
            };

            _repository.Edit(gameDomain);
            _repository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            
            _repository.Delete(id);
            _repository.SaveChanges();
            
            return Ok();
        }
    }
}