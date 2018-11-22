using System.Linq;
using TicketApp.Core.Entities.Enums;
using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class ViewAdministrators : ViewUsers
    {
        public ViewAdministrators(ServicesUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override string CommandKey
        {
            get { return $"{base.CommandKey} admin"; }
        }

        public override string Description
        {
            get { return "Display all available administrators"; }
        }

        public override void Execute(string[] args, string enteredCommandKey)
        {
            var admins = UnitOfWork.UserService.Collection.Where(u => u.Roles.Any(r => r.Name == RoleName.Administrator.ToString()))
                .ToArray();
            DisplayUsers(admins);
        }
    }
}