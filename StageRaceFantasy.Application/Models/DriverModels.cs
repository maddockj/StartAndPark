using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;

namespace StartAndPark.Application
{
    public class DriverDto : IMapFrom<Driver>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
