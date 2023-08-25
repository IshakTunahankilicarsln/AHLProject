namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.MixDto
{
    public class ProductAndPicturePutDto
    {
        public ProductPutDto? ProductPutDto { get; set; }
        public List<string>? PictureImages { get; set; }
    }
}
