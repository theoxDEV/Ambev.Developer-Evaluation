using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<SaleItem, CreateSaleItemResponse>();
            CreateMap<Sale, CreateSaleResponse>();
            CreateMap<Sale, GetAllSalesResponse>();
            CreateMap<Sale, GetSaleByIdResponse>();
            CreateMap<Sale, UpdateSaleResponse>();
            CreateMap<Sale, CancelSaleResponse>();
            CreateMap<Sale, CreateSaleResponse>();

            CreateMap<SaleItem, GetSaleItemResponse>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));
        }
    }
}
