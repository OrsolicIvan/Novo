using APARTMENTS.Models;


namespace APARTMENTS.DtosComment
{
    public class GetCommentDto
    {
        public int ApartmentId { get; set; }
        public string OwnerComment { get; set; }
        public string ApartmentComment { get; set; }

        

    }
}
