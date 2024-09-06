namespace PoKeMonweb.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PoKemonOwner> PoKemonOwners { get; set; }
        public ICollection<PoKemonCategory> PoKemonCategories { get; set; }
    }
}
