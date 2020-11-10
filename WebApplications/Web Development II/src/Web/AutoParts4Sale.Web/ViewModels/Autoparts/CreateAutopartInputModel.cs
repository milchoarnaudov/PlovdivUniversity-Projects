namespace AutoParts4Sale.Web.ViewModels.Autoparts
{
    public class CreateAutopartInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int MakeId { get; set; }

        public int CategoryId { get; set; }

        public int ModelId { get; set; }
    }
}
