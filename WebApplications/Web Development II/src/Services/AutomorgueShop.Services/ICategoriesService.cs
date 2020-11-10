namespace AutomorgueShop.Services
{
    using AutomorgueShop.DTO;
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<CategoryDTO> GetAll();
    }
}
