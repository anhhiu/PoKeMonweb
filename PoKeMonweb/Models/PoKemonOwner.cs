namespace PoKeMonweb.Models
{
    public class PoKemonOwner
    {
        public int PoKemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
