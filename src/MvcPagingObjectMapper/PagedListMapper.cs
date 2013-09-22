using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;

namespace MvcPaging.AutoMapper
{
    public class PagedListMapper : IObjectMapper
    {
        private IMappingEngineRunner _mapper;

        public TDest Map<TDest>(object source)
        {
            TypeMap typeMap = _mapper.ConfigurationProvider.FindTypeMapFor(source, default(TDest), source.GetType(), typeof(TDest));

            var mappingOperationOptions = new MappingOperationOptions();
            var resolutionContext = new ResolutionContext(typeMap, source, source.GetType(), typeof(TDest), mappingOperationOptions);

            return (TDest)_mapper.Map(resolutionContext);
        }

        public object Map(ResolutionContext context, IMappingEngineRunner mapper)
        {
            _mapper = mapper;

            Type destinationType = context.DestinationType.GetGenericArguments()[0];

            Type sourceType = context.SourceType.GetGenericArguments()[0];

            MethodInfo method = typeof(PagedListMapper).GetMethod("CreatePagedList")
                .MakeGenericMethod(sourceType, destinationType);

            return method.Invoke(this, new[] { context.SourceValue });
        }

        public bool IsMatch(ResolutionContext context)
        {
            return typeof(IPagedList).IsAssignableFrom(context.SourceType)
                && typeof(IPagedList).IsAssignableFrom(context.DestinationType);
        }

        public IPagedList<TDest> CreatePagedList<TSource, TDest>(IPagedList<TSource> source)
        {
            var destination = source.Select(item => Map<TDest>(item)).ToList();

            return destination.ToPagedList(source.PageIndex, source.PageSize, source.TotalItemCount);
        }

        /// <summary>
        /// This method is used to add the PagedObjectListMapper to the top of AllMappers.
        /// </summary>
        public static void Register()
        {
            var allMappers = new[] { new PagedListMapper() }.Union(MapperRegistryOverride.AllMappers());
            MapperRegistryOverride.AllMappers = () => allMappers;
        }
    }
}