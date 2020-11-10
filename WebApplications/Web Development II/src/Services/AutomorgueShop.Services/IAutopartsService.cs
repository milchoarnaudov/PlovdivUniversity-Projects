namespace AutomorgueShop.Services
{
    using AutomorgueShop.DTO;
    using AutomorgueShop.DTO.Autoparts;
    using System.Collections.Generic;

    public interface IAutopartsService
    {
        IEnumerable<AutopartDTO> GetAll();

        void Create(CreateAutopartDTO autopart);
    }
}
