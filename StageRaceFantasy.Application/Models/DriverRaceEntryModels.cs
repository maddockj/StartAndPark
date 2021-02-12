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
        public int DriverId { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public bool IsEntered { get; set; }
        public string CarNumber { get; set; }
        public string Tier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DriverRaceEntry, DriverRaceEntryDto>();

            profile.CreateMap<Driver, DriverRaceEntryDto>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DriverFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.LastName));
        }
    }

    public class CreateDriverRaceEntryDto : IMapFrom<DriverRaceEntry>
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
    }
}
