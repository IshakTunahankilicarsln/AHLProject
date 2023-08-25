namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.MixDto
{
    public class ProductAndPicturePostDto
    {
        public ProductPostDto? Productpostdto { get; set; }
        public List<string>? PictureImages { get; set; }
    }
}
