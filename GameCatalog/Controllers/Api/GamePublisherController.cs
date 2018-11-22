using GameCatalog.App_Start;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;
using GameCatalog.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GameCatalog.Controllers.Api
{
    public class GamePublisherController : ApiController
    {
        private readonly IGamePublisherRepository _repository;

        public GamePublisherController(IGamePublisherRepository repository)
        {
            _repository = repository;
        }

        [Route("api/publishers")]
        public IHttpActionResult GetPublishers()
        {
            var mapper = MappingProfile.GetMapper();

            var publishers = mapper.Map<IEnumerable<GamePublisher>,
                                   IEnumerable<GamePublisherViewModel>>(_repository.Get().ToList());

            return Ok(publishers);
        }

        [Route("api/publishers")]
        public IHttpActionResult AddPublisher(GamePublisher pub)
        {
            _repository.Add(pub);
            _repository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePublisher(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.SaveChanges();

            return Ok();
        }
    }
}
