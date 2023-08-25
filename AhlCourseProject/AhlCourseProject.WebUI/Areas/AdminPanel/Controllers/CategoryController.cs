using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class CategoryController : Controller
    {
        private readonly IHttpApiService _service;
        private readonly IWebHostEnvironment _webhost;
        private object oldImagePath;

        public CategoryController(IHttpApiService service, IWebHostEnvironment webhost) { _service = service; _webhost = webhost; }
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<CategoryItem>>>("/Categories");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var responseget = await _service.GetData<ResponseBody<CategoryItem>>($"/Categories/{id}");

            return Json(new 
            {
                CategoryId = responseget.Data.CategoryId,
                CategoryName = responseget.Data.CategoryName,
                Description = responseget.Data.Description,
                PicturePath = responseget.Data.PicturePath
            });


        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _service.DeleteData($"/Categories/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "İşlem Başarılı" });

            return Json(new { IsSuccess = false, Message = "İşlem Başarısız" });

        }


        //--------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Save(NewCategoryDto dto, IFormFile categoryImage)
        {

            if (categoryImage == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir" });

            if (!categoryImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Dadece resim dosyadı yüklenebilir!" });

            if (categoryImage.Length >= 1024 * 4000)
                return Json(new { IsSuccess = false, Message = "resim boyutu bukadar büyük olamaz!" });


            var randomfilename = $"{Guid.NewGuid()}{Path.GetExtension(categoryImage.FileName)}";
            var uploadPath = $@"{_webhost.WebRootPath}/adminPanel/Images/categoryImages/{randomfilename}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await categoryImage.CopyToAsync(fs);
            }

            var postData = new PostCategoryDto
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                PicturePath = $@"/adminPanel/Images/categoryImages/{randomfilename}"
            };

            var response =
              await _service.PostData<ResponseBody<CategoryItem>>("/Categories", JsonSerializer.Serialize(postData));

            if (response.StatusCode >= 200 || response.StatusCode <= 204)
                return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });

            var errorMessages = string.Empty;
            foreach (var item in response.ErrorMessage)
            {
                errorMessages += item + "<br/>";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Kategori Kaydedilemedi <br /> {errorMessages}"
            });


        }

        //--------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Update(PutCategoryDto dto, IFormFile categoryImageEdit)
        {
            #region Picture Controll
            if (categoryImageEdit == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir" });

            if (!categoryImageEdit.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Dadece resim dosyadı yüklenebilir!" });

            if (categoryImageEdit.Length >= 1024 * 4000)
                return Json(new { IsSuccess = false, Message = "resim boyutu bukadar büyük olamaz!" });
            #endregion


            var randomfilename = $"{Guid.NewGuid()}{Path.GetExtension(categoryImageEdit.FileName)}";
            var uploadPath = $@"{_webhost.WebRootPath}/adminPanel/Images/categoryImages/{randomfilename}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await categoryImageEdit.CopyToAsync(fs);
            }

            var postData = new PutCategoryDto
            {
                CategoryId = dto.CategoryId,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                PicturePath = $@"/adminPanel/Images/categoryImages/{randomfilename}"
            };

            var response =
              await _service.PutData("/Categories", JsonSerializer.Serialize(postData));


            if (response)
                return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });
            else
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = $"Kategori Kaydedilemedi <br />"
                });
            }
        }
    }
}
