namespace AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes
{
    public class ResponseBody<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public AdminPanelUseritem? admin { get; set; }   
    }
}
