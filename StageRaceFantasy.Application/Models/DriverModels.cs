using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;

namespace StartAndPark.Application
{
    public class DriverDto : IMapFrom<Driver>
    {
        public int Id { get; set; }
        public int NascarId { get; set; }
        public string Name { get; set; }
    }
}
