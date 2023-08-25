using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;

namespace AhlCourseProject.WebUI.ApiServices
{
    public interface IHttpApiService
    {
        Task<T> GetData<T>(string reqURI);
        Task<T> PostData<T>(string reqURI,string jsonData);
        Task<bool> PutData(string reqURI, string jsonData);
        Task<bool> DeleteData(string reqURI);

    }
}
