using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace StageRaceFantasy.Application.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(IsIMapperType))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = GetMappingMethodInfo(type);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        private static MethodInfo GetMappingMethodInfo(Type type)
        {
            return type.GetMethod("Mapping")
                ?? type.GetInterface("IMapFrom")?.GetMethod("Mapping")
                ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
        }

        private static bool IsIMapperType(Type i)
        {
            if (i == typeof(IMapFrom)) return true;

            if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
            {
                return true;
            }

            return false;
        }
    }
}
