using API.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Core.Pagination;

namespace API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(IPaginatedList<>), typeof(IPaginatedList<>)).ConvertUsing(typeof(Converter<,>));
        CreateMap<Initiative, InitativeDto>().ReverseMap();
    }

    private class Converter<TSource, TDestination> : ITypeConverter<IPaginatedList<TSource>, IPaginatedList<TDestination>> where TSource : class where TDestination : class
    {
        public IPaginatedList<TDestination> Convert(
            IPaginatedList<TSource> source,
            IPaginatedList<TDestination> destination,
            ResolutionContext context) =>
            new PaginatedList<TDestination>(context.Mapper.Map<List<TSource>, List<TDestination>>(source.Items),
                source.TotalCount, source.PageIndex, source.PageSize);
    }
}

