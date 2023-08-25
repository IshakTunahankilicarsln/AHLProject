using AutoMapper;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Dtos.Admin;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Dtos.Customer;
using NLayer_Task.Model.Dtos.Order;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Dtos.ProductPicturePath;
using NLayer_Task.Model.Dtos.User;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Mapper.AutoMapper.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Product------------------------------------------------------------
            CreateMap<Product, ProductGetDto>()
             .ForMember(desc => desc.CategoryName, opt => opt.MapFrom(src => src.Category == null ? "" : src.Category.CategoryName));
            CreateMap<ProductGetDto, Product>();
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();
            //-------------------------------------------------------------------



            //Category-----------------------------------------------------------
            CreateMap<Category, CategoryGetDto>();
            //.ForMember(desc => desc.ProductCount, opt => opt.MapFrom(src => src.Product.Count()));

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
            //------------------------------------------------------------------



            //Addres------------------------------------------------------------
            CreateMap<Addres, AddresGetDto>()
                .ForMember(desc => desc.CustomerName, op => op.MapFrom(src => src.Customer == null ? "" : src.Customer.FirstName + " " + src.Customer.LastName));
            CreateMap<AddresPostDto,Addres>();
            CreateMap<AddresPutDto, Addres>();

            //CreateMap<CategoryPutDto, Category>();
            //-------------------------------------------------------------------



            //Admin------------------------------------------------------------
            CreateMap<Admin, AdminGetDto>();
            //    .ForMember(desc => desc.CustomerName, op => op.MapFrom(src => src.Customer == null ? "" : src.Customer.FirstName + " " + src.Customer.LastName));
            CreateMap<AdminPostDto, Admin>();
            CreateMap<AdminPutDto, Admin>();
            //-------------------------------------------------------------------


            //User------------------------------------------------------------
            CreateMap<User, UserGetDto>();
            //    .ForMember(desc => desc.CustomerName, op => op.MapFrom(src => src.Customer == null ? "" : src.Customer.FirstName + " " + src.Customer.LastName));
            //CreateMap<AddresGetDto, Addres>();
            //CreateMap<CategoryPutDto, Category>();
            //-------------------------------------------------------------------


            //Admin------------------------------------------------------------
            CreateMap<Order, OrderGetDto>();
                //.ForMember(desc => desc.OrderDate, op => op.MapFrom(src => src.OrderDate == null ? "" : src.OrderDate.Value.Day.ToString() + "-" + src.OrderDate.Value.Month.ToString() + "-" + src.OrderDate.Value.Year.ToString()))
                //.ForMember(desc => desc.DeliveryDate, op => op.MapFrom(src => src.DeliveryDate == null ? "" : src.DeliveryDate.Value.Day.ToString() + "-" + src.DeliveryDate.Value.Month.ToString() + "-" + src.DeliveryDate.Value.Year.ToString()))
                //.ForMember(desc => desc.PostedDate, op => op.MapFrom(src => src.PostedDate == null ? "" : src.PostedDate.Value.Day.ToString() + "-" + src.PostedDate.Value.Month.ToString() + "-" + src.PostedDate.Value.Year.ToString()));
            CreateMap<Order, OrderPostDto>();
            //CreateMap<CategoryPutDto, Category>();
            //-------------------------------------------------------------------





            //Customer-----------------------------------------------------------
            CreateMap<Customer, CustomerGetDto>();
            CreateMap<CustomerPostDto, Customer > ();
            CreateMap<CustomerPutDto, Customer > ();
            //-------------------------------------------------------------------

            //Customer-----------------------------------------------------------
            CreateMap<ProductPicturePath, ProductPicturePathGetDto>();
            CreateMap<ProductPicturePathPostDto, ProductPicturePath>();
            CreateMap<ProductPicturePathPutDto, ProductPicturePath>();

            //-------------------------------------------------------------------

        }

    }
}
