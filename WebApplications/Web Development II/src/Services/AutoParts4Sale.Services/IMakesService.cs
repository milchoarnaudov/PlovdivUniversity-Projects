namespace AutomorgueShop.Services
{
    using AutomorgueShop.DTO;
    using System.Collections.Generic;

    public interface IMakesService
    {
        IEnumerable<MakeModelDTO> GetAll();
    }
}
