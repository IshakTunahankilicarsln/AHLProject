using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.MixDto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class ProductController : Controller
    {
        private readonly IHttpApiService _service;
        private readonly IWebHostEnvironment _webhost;
        public ProductController(IHttpApiService service, IWebHostEnvironment webhost) { _service = service; _webhost = webhost; }


        public async Task<IActionResult> Index()
        {
            var responseP = await _service.GetData<ResponseBody<List<ProductItem>>>("/Products");
            ViewBag.uri = $"{_webhost.WebRootPath}";
            var responseC = await _service.GetData<ResponseBody<List<CategoryItem>>>("/Categories");

            var model = new ViewContenttype();
            model.RroductItem = responseP.Data;
            model.CategoryItem = responseC.Data;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _service.DeleteData($"/Products/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Ürün Silindi" });

            else
            {
                return Json(new { IsSuccess = false, Message = "Ürün Silinemedi" });

            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var responseP = await _service.GetData<ResponseBody<ProductItem>>($"/Products/{id}");

            return Json(new ProductItem
            {
                ProductName = responseP.Data.ProductName,
                CategoryName = responseP.Data.CategoryName,
                ProductMaterial = responseP.Data.ProductMaterial,
                ProductID = responseP.Data.ProductID,
                CategoryID = responseP.Data.CategoryID,
                UnitPrice = responseP.Data.UnitPrice,
                UnitsInStock = responseP.Data.UnitsInStock
            });

        }

        [HttpPost]
        public async Task<IActionResult> GetProductImage([FromRoute] int id)
        {
            var responseP = await _service.GetData<ResponseBody<ProductItem>>($"/Products/{id}");
            var pathfin = new List<string>();            
            var productPath = responseP.Data.ProductPicturePath;
            foreach (var item in productPath)
            {
                pathfin.Add(item.PicturePath);
            }
            return Json(new 
            {
                Path = pathfin
            });

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductPostDto dto, List<IFormFile> productImagesEdit)
        {
            if (productImagesEdit.Count <= 0)
                return Json(new { IsSuccess = false, Message = "Ürün resmi seçilmelidir" });

            /*
             if (image == null)
                return Json(new { IsSuccess = false, Message = "Kategori resmi seçilmelidir" });

                if (!image.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Dadece resim dosyadı yüklenebilir!" });

                if (image.Length >= 1024 * 4000)
                return Json(new { IsSuccess = false, Message = "resim boyutu bukadar büyük olamaz!" });
            */
            var pictureImages = new List<string>();
            foreach (var productimage in productImagesEdit)
            {
                var randomfilename = $"{Guid.NewGuid()}{Path.GetExtension(productimage.FileName)}";
                var uploadPath = $@"{_webhost.WebRootPath}/adminPanel/Images/productImage/{randomfilename}";

                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    await productimage.CopyToAsync(fs);
                }
                var postPath = $"/adminPanel/Images/productImage/{randomfilename}";
                pictureImages.Add(postPath);
            }

            var productpost = new ProductPostDto
            {
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                CategoryId = dto.CategoryId,
                ProductMaterial = dto.ProductMaterial
            };

            var postdto = new ProductAndPicturePostDto();
            postdto.Productpostdto = productpost;
            postdto.PictureImages = pictureImages;


            var response =
              await _service.PostData<ResponseBody<CategoryItem>>("/Products/byMix", JsonSerializer.Serialize(postdto));

            if (response.ErrorMessage != null)
            {
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
            else
            {
                if (response.StatusCode >= 200 || response.StatusCode <= 204)
                    return Json(new { IsSuccess = true, Message = "Ürün ve resimler Başarıyla Kaydedildi" });
            }

            return Json(new { IsSuccess = true, Message = "Kayıt Yapılamadı" });
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductPutDto dto, List<IFormFile> productImagesEdit)
        {
            if (productImagesEdit.Count <= 0)
                return Json(new { IsSuccess = false, Message = "Ürün resmi seçilmelidir" });

            var pictureImages = new List<string>();
            foreach (var productimage in productImagesEdit)
            {
                var randomfilename = $"{Guid.NewGuid()}{Path.GetExtension(productimage.FileName)}";
                var uploadPath = $@"{_webhost.WebRootPath}/adminPanel/Images/productImage/{randomfilename}";

                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    await productimage.CopyToAsync(fs);
                }
                var postPath = $"/adminPanel/Images/productImage/{randomfilename}";
                pictureImages.Add(postPath);
            }

            var productput = new ProductPutDto
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                CategoryID = dto.CategoryID,
                ProductMaterial = dto.ProductMaterial
            };

            var postdto = new ProductAndPicturePutDto();
            postdto.ProductPutDto = productput;
            postdto.PictureImages = pictureImages;

            var response =
              await _service.PutData("/Products/byMix", JsonSerializer.Serialize(postdto));

            if(response)
                return Json(new { IsSuccess = true, Message = "Güncelleme Başarılı" });
            else
            {
                return Json(new { IsSuccess = false, Message = "Kayıt Yapılamadı" });

            }
        }
    }

}
