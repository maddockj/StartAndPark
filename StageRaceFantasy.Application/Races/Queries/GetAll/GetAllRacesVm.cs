﻿using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace StartAndPark.Application.Races.Queries.GetAll
{
    public class GetAllRacesVm : IListVm<RaceDto>
    {
        public List<RaceDto> ItemList { get; set; }
    }

    public class RaceDto : IMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public DateTime? StartTime { get; set; }
        public bool IsComplete { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Race, RaceDto>()
                .ForMember(dto => dto.TrackName, x => x.MapFrom(race => race.Track.Name));
        }
    }
}
