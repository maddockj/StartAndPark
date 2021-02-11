using AutoMapper;

namespace StageRaceFantasy.Application.Common.AutoMapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }

    public interface IMapFrom
    {
        void Mapping(Profile profile);
    }
}
