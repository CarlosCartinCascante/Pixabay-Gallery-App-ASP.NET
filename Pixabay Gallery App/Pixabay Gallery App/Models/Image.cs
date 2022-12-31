namespace Pixabay_Gallery_App.Models
{
    public class Image
    {
        public int? Id { get; set; }
        public string? Type { get; set; }

        public string? WebFormatURL { get; set; }

        public int? Likes { get; set; }
    }
}
