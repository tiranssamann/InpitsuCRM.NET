using Inpitsu.WebAPI.Models.User;

namespace Inpitsu.WebAPI.Models.Task
{
    public class TaskExtendedListingModel : TaskListingModel
    {
        public string CreatedOn { get; init; }

        public string Board { get; init; }

        public UserListingModel Owner { get; init; }
    }
}
