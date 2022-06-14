namespace APARTMENTS.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string OwnerComment { get; set; }
        public string ApartmentComment { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }


    }
}
