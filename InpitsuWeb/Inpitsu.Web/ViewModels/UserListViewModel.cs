using Inpitsu.Data.DtoObjects;
using Inpitsu.Filters;

namespace Inpitsu.Web.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserWithRolesDto> Users { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}
