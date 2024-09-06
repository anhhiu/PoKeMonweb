namespace PoKeMonweb.Models
{
    public class PoKemonCategory
    {
        public int PoKemonId { get; set; }
        public int CategoryId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
