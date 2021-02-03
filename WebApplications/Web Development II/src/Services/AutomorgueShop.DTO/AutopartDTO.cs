namespace AutomorgueShop.DTO.Autoparts
{
    using System;

    public class AutopartDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
