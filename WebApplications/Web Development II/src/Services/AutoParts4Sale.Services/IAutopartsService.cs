namespace AutoParts4Sale.Services
{
    using AutoParts4Sale.DTO;
    using AutoParts4Sale.DTO.Autoparts;
    using System.Collections.Generic;

    public interface IAutopartsService
    {
        IEnumerable<AutopartDTO> GetAll();

        void Create(CreateAutopartDTO autopart);
    }
}
