using System;
using System.Collections.Generic;

namespace DNELms.ModelMappers
{
    public interface IModelMapper
    {
        object Map(Type src, Type dest, object source);
        TDestination Map<TSource, TDestination>(TSource source);
        List<TDestination> MapList<TSource, TDestination>(List<TSource> source);
    }
}