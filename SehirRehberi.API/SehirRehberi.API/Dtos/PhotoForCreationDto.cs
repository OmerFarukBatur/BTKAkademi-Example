namespace SehirRehberi.API.Dtos
{
    public class PhotoForCreationDto
    {
        public PhotoForCreationDto()
        {
            DateAdded = DateTime.UtcNow;
        }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Descriptions { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
    }
}
