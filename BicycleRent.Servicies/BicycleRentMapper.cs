using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;

namespace BicycleRent.Servicies;

/// <summary>
/// Класс для преобразования DTO сущности в саму сущности и обратно
/// </summary>
public class BicycleRentMapper : Profile
{
    /// <summary>
    /// Класс для маппинга данных в DTO и обратно
    /// </summary>

    public BicycleRentMapper()
    {
        CreateMap<BicycleType, BicycleTypeDto>().ReverseMap();
        CreateMap<BicycleRenter, BicycleRenterDto>().ReverseMap();
        CreateMap<Bicycle, BicycleDto>().ReverseMap();
        CreateMap<Rent, RentDto>().ReverseMap();
    }

    //public BicycleRentMapper(
    //    IRepository<BicycleType, int> typeRepository,
    //    IRepository<Bicycle, int> bicycleRepository,
    //    IRepository<BicycleRenter, int> renterRepository
    //    )
    //{
    //    CreateMap<BicycleType, BicycleTypeDto>().ReverseMap();
    //    CreateMap<BicycleRenter, BicycleRenterDto>().ReverseMap();

    //    CreateMap<Bicycle, BicycleDto>()
    //        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.TypeId)).ReverseMap()
    //        .ForMember(dest => dest.Type, opt => opt.MapFrom(src => typeRepository.GetItem(src.TypeId)));

    //    CreateMap<Rent, RentDto>()
    //        .ForMember(dest => dest.BicycleId, opt => opt.MapFrom(src => src.Bicycle.BicycleId)).ReverseMap()
    //        .ForMember(dest => dest.Bicycle, opt => opt.MapFrom(src => bicycleRepository.GetItem(src.BicycleId)))
    //        .ForMember(dest => dest.Renter, opt => opt.MapFrom(src => renterRepository.GetItem(src.RenterId))).ReverseMap()
    //        .ForMember(dest => dest.RenterId, opt => opt.MapFrom(src => src.Renter.RenterId));
    //}
}
