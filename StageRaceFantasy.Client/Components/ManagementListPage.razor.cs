using StartAndPark.Application.Common.Interfaces;

namespace StartAndPark.Client.Components
{
    public partial class ManagementListPage<TListModel, TItem> where TListModel : class, IListVm<TItem> { }
}
