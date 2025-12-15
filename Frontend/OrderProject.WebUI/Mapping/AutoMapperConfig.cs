using AutoMapper;
using OrderProject.EntityLayer.Concrete;
using OrderProject.WebUI.Dtos.AdminUserDto;
using OrderProject.WebUI.Dtos.CategoryDto;
using OrderProject.WebUI.Dtos.ContactDto;
using OrderProject.WebUI.Dtos.LoginDto;
using OrderProject.WebUI.Dtos.ProductDto;
using OrderProject.WebUI.Dtos.RegisterDto;
using OrderProject.WebUI.Models.Mail;

namespace OrderProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AppUser, CreateUserDto>().ReverseMap();
            //Login
            CreateMap<AppUser, LoginUserDto>().ReverseMap();

            //Product
            CreateMap<Product, ResultProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();

            //Category
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            //AdminUserList
            CreateMap<AppUser, ResultUsersDto>().ReverseMap();

            //Contact Message
            CreateMap<Contact, CreateContactMessageDto>().ReverseMap();

            //MAil
            CreateMap<SendEmail, SendEmailViewModel>().ReverseMap();

        }
    }
}
