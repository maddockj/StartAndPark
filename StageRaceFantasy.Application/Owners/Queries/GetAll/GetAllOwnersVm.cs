using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application.Owners.Queries.GetAll
{
    public class GetAllOwnersVm
    {
        public List<OwnerDto> Owners { get; set; }
    }

    public class OwnerDto : IMapFrom<Owner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
