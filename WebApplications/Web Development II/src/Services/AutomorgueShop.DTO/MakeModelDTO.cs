namespace AutomorgueShop.DTO
{
    using System.Collections.Generic;

    public class MakeModelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ModelDTO> Models { get; set; }
    }
}
