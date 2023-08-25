using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Interface
{
    public interface IProductBS
    {
        Task<ApiResponse<List<ProductGetDto>>> GetAllProductAsync(params string[] includelist);
        Task<ApiResponse<List<ProductGetDto>>> GetByProductNameAsync(string name, params string[] includelist);
        Task<ApiResponse<List<ProductGetDto>>> GetByMaterialAsync(string material, params string[] includelist);
        Task<ApiResponse<List<ProductGetDto>>> GetByUnitPriceAsync(decimal min, decimal max, params string[] includelist);
        Task<ApiResponse<List<ProductGetDto>>> GetByCategryIdAsync(int id, params string[] includelist);
        Task<ApiResponse<ProductGetDto>> GetByIdAsync(int id, params string[] includelist);
        Task<ApiResponse<Product>> AddAsync(ProductPostDto productdto, params string[] includelist);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto productPutDto);
        Task<ApiResponse<NoData>> DeletebyIdAsync(int id);
    }
}
