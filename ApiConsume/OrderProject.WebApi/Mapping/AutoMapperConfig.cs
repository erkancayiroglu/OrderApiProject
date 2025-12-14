using AutoMapper;
using OrderProject.DtoLayer.About;
using OrderProject.DtoLayer.Booking;
using OrderProject.DtoLayer.Category;
using OrderProject.DtoLayer.Contact;
using OrderProject.DtoLayer.MessageCategory;
using OrderProject.DtoLayer.OrderBookDto1;
using OrderProject.DtoLayer.OrderDto1;
using OrderProject.DtoLayer.Products;
using OrderProject.DtoLayer.Restaurant;
using OrderProject.DtoLayer.SepetItems;
using OrderProject.DtoLayer.Staff;
using OrderProject.EntityLayer.Concrete;

namespace OrderProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Product Dto Mappings
           CreateMap<CreateProductDto, Product>().ReverseMap();
              CreateMap<UpdateProductDto, Product>().ReverseMap();
            //Category Dto Mappings
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            //Staff Dto Mappings
            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            //About Dto Mappings
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            //Booking Dto Mappings
            CreateMap<CreateBookingDto, Booking>().ReverseMap();

            //Restaurant Dto Mappings
            CreateMap<CreateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<UpdateRestaurantDto, Restaurant>().ReverseMap();

            //Contact Dto Mappings
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

            //MessageCategory Dto Mappings

            CreateMap<CreateMessageCategoryDto, MessageCategory>().ReverseMap();
            CreateMap<UpdateMessageCategoryDto, MessageCategory>().ReverseMap();

            //SeperItem Dto Mappings

            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderBookDto, OrderBook>().ReverseMap();


        }
    }
}
