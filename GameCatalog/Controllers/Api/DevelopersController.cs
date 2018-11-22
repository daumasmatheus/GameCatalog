using GameCatalog.App_Start;
using GameCatalog.DAL.Interfaces;
using GameCatalog.Entities;
using GameCatalog.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GameCatalog.Controllers.Api
{
    public class DevelopersController : ApiController
    {
        private readonly IDeveloperRepository _repository;

        public DevelopersController(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        [Route("api/developers")]
        public IHttpActionResult GetDevs()
        {
            var mapper = MappingProfile.GetMapper();

            var devs = mapper.Map<IEnumerable<Developer>,
                                   IEnumerable<DeveloperViewModel>>(_repository.Get().ToList());

            return Ok(devs);
        }

        [Route("api/developers")]
        [HttpPost]
        public IHttpActionResult AddDev(Developer dev)
        {
            _repository.Add(dev);
            _repository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeveloper(int id)
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
