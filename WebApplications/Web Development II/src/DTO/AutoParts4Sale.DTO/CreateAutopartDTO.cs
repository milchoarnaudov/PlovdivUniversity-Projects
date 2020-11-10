namespace AutoParts4Sale.DTO
{
    public class CreateAutopartDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }
    }
}
