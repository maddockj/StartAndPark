using AutoMapper;
using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application
{
    public class GetAllDriverRaceEntriesVm : IListVm<DriverRaceEntryDto>
    {
        public List<DriverRaceEntryDto> ItemList { get; set; }
    }

    public class DriverRaceEntryDto : IMapFrom
    {
        public int RaceId { get; set; }
        public int NascarRaceId { get; set; }
        public int DriverId { get; set; }
        public int NascarDriverId { get; set; }
        public string Name { get; set; }
        public bool IsEntered { get; set; }
        public string CarNumber { get; set; }
        public string Tier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RaceEntry, DriverRaceEntryDto>();

            profile.CreateMap<Race, DriverRaceEntryDto>()
                .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NascarRaceId, opt => opt.MapFrom(src => src.NascarId));

            profile.CreateMap<Driver, DriverRaceEntryDto>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NascarDriverId, opt => opt.MapFrom(src => src.NascarId));
        }
    }

    public class CreateDriverRaceEntryDto : IMapFrom<RaceEntry>
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public string CarNumber { get; set; }
        public string Tier { get; set; }
    }
}
