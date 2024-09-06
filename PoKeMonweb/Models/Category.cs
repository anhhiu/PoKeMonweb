namespace PoKeMonweb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PoKemonCategory> PoKemonCategories { get; set; }
    }
}
