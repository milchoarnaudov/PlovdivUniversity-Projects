namespace AutoParts4Sale.Services
{
    using AutoParts4Sale.DTO;
    using System.Collections.Generic;

    public interface IMakesService
    {
        IEnumerable<MakeModelDTO> GetAll();
    }
}
