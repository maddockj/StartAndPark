using StartAndPark.Application.Common.AutoMapper;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Domain.Entities;
using System.Collections.Generic;

namespace StartAndPark.Application.Owners.Queries.GetAll
{
    public class GetAllOwnersVm : IListVm<OwnerDto>
    {
        public List<OwnerDto> ItemList { get; set; }
    }

    public class OwnerDto : IMapFrom<Owner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
