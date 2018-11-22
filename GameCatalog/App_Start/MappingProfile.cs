using AutoMapper;
using GameCatalog.Entities;
using GameCatalog.ViewModels;

namespace GameCatalog.App_Start
{
    public static class MappingProfile
    {
        private static IMapper Mapper;

        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameViewModel>();
                cfg.CreateMap<Game, GameEditViewModel>();
                cfg.CreateMap<GamePublisher, GamePublisherViewModel>();
                cfg.CreateMap<Developer, DeveloperViewModel>();
            });

            Mapper = config.CreateMapper();
            return Mapper;
        }
    }
}