using System.Collections.Generic;
using System.Linq;
using TicketApp.Core.Entities;
using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class ViewUsers : ICommand
    {
        protected readonly ServicesUnitOfWork UnitOfWork;
        public ViewUsers(ServicesUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual string CommandKey
        {
            get { return "users view"; }
        }

        public virtual string Description
        {
            get { return "Display all available users"; }
        }

        public virtual void Execute(string[] args, string enteredCommandKey)
        {
            var users = UnitOfWork.UserService.Collection.ToArray();
            DisplayUsers(users);
        }

        protected virtual void DisplayUsers(ICollection<User> users)
        {
            var longestId = users.Max(u => u.Id.ToString().Length);
            var longestName = users.Max(u => u.GetFullName().Length);
            var longestRoles = users.Max(u => u.GetRolesString().Length);

            foreach (var user in users)
            {
                System.Console.WriteLine("{0} {1} {2}",
                    user.Id.ToString().PadRight(longestId),
                    user.GetFullName().PadRight(longestName),
                    user.GetRolesString().PadRight(longestRoles));
            }
        }
    }
}