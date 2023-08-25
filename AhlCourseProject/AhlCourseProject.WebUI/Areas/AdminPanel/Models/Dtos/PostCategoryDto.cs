namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos
{
    public class PostCategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string? Base64Picture { get; set; }
        public string? PicturePath { get; set; }
    }
}
