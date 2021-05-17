using AutoMapper;
using System;
using System.Collections.Generic;

namespace DNELms.ModelMappers
{
    public class ModelMapper : IModelMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapperConfig = new MapperConfiguration(s =>
              {
                  s.CreateMap<TSource, TDestination>();
              });
            IMapper mapper = mapperConfig.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }
        public List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            var mapperConfig = new MapperConfiguration(s =>
              {
                  s.CreateMap<TSource, TDestination>();
              });
            IMapper mapper = mapperConfig.CreateMapper();
            return mapper.Map<List<TSource>, List<TDestination>>(source);
        }
        public object Map(Type src, Type dest, object source)
        {
            var mapperConfig = new MapperConfiguration(s =>
              {
                  s.CreateMap(src, dest);
              });
            IMapper mapper = mapperConfig.CreateMapper();
            return mapper.Map(source, src, dest);
        }
    }
}
