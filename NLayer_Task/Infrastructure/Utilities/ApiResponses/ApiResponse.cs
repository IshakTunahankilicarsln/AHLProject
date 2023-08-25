using System.Collections;

namespace Infrastructure.Utilities.ApiResponses
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; } = 204;
        public List<string>? ErrorMesage { get; set; }
        public int? ListCount { get; set; }
        

        public static ApiResponse<T> Success(int statusCode, T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                ListCount = data is IList list ? list.Count : 0,

            };
        }
        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
            };
        }
        public static ApiResponse<T> Fail(int statusCode, List<string> errorMesage)
        {
            if (statusCode == 400)
            {
                return new ApiResponse<T>
                {
                    StatusCode = statusCode,
                    ErrorMesage = new List<string> {"Veri doğrulma hatası" , "Details : " + errorMesage}
                };
            }
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMesage = errorMesage
            };
        }
        public static ApiResponse<T> Fail(int statusCode,string errorMesage)
        {
            if (statusCode == 400)
            {
                return new ApiResponse<T>
                {
                    StatusCode = statusCode,
                    ErrorMesage = new List<string> { "Veri doğrulma hatası", "Details : " + errorMesage }
                };
            }
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMesage = new List<string> { "Hata", "Details : " + errorMesage }
            };
        }

    }
}
