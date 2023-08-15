using AutoMapper;
using EcomProductManager.Models;
using EcomProductManager.Requests;
using EcomProductManager.Responses;

namespace EcomProductManager.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductRequests, Product>();
            CreateMap<CategoryRequests, Category>();
            CreateMap<Product, ProductResponse>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
