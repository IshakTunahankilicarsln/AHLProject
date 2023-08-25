using Microsoft.Extensions.DependencyInjection;
using NLayer_Task.Business.Implementation;
using NLayer_Task.Business.Interface;
using NLayer_Task.Business.Mapper.AutoMapper.Mappers;
using NLayer_Task.DataAccess.EF.Implementations;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Extension.AlExtension
{
    public static class AddBussinesServiceExtensions
    {
        public static void AddBusinessService(this IServiceCollection service)
        {
            //IOC-------------------------------------------------------------------------------

            service.AddAutoMapper(typeof(AutoMapperProfile));
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductBS, ProductBS>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICategoryBS, CategoryBS>();
            service.AddScoped<IAddresRepository, AddresRepository>();
            service.AddScoped<IAddresBS, AddresBS>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<ICustomerBS, CustomerBS>();
            service.AddScoped<IAdminRepository, AdminRepository>();
            service.AddScoped<IAdminBS, AdminBS>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IOrderBS, OrderBS>();
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IUserBS, UserBS>();
            service.AddScoped<IProductPicturePathRepository, ProductPicturePathRepository>();
            service.AddScoped<IProductPicturePathBS, ProductPicturePathBS>();

            //----------------------------------------------------------------------------------
        }
    }
}
