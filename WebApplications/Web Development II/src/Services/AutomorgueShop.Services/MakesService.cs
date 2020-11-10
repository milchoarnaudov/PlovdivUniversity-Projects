namespace AutomorgueShop.Services
{
    using AutomorgueShop.Data.Repositories;
    using AutomorgueShop.DTO;
    using System.Collections.Generic;
    using System.Linq;

    public class MakesService : IMakesService
    {
        private readonly CarMakeRepository carMakeRepository;

        public MakesService(CarMakeRepository carMakeRepository)
        {
            this.carMakeRepository = carMakeRepository;
        }

        public IEnumerable<MakeModelDTO> GetAll()
        {
            return carMakeRepository.GetAll().Select(x => new MakeModelDTO
            {
                Id = x.Id,
                Name = x.Name,
                Models = x.CarModels.Select(x => new ModelDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                })
            });
        }
    }
}
