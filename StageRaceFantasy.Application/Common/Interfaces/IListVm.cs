using System.Collections.Generic;

namespace StartAndPark.Application.Common.Interfaces
{
    public interface IListVm<TItem>
    {
        public List<TItem> ItemList { get; set; }
    }
}
