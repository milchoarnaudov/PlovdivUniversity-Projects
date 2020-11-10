namespace AutoParts4Sale.Services
{
    using AutoParts4Sale.Data.Repositories;
    using AutoParts4Sale.DTO;
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
