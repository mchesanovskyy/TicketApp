using TicketApp.Core.Entities;
using TicketApp.Core.Entities.Enums;
using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class AddAdministratorCommand : ICommand
    {
        private readonly ServicesUnitOfWork _unitOfWork;

        public AddAdministratorCommand(ServicesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public string Description
        {
            get { return "Create an Administrator"; }
        }

        public string CommandKey
        {
            get { return "users add admin"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            System.Console.Write("Please enter first name: ");
            var firstName = System.Console.ReadLine();

            System.Console.Write("Please enter last name: ");
            var lastName = System.Console.ReadLine();

            System.Console.Write("Please enter email: ");
            var email = System.Console.ReadLine();

            System.Console.Write("Please enter password: ");
            var password = System.Console.ReadLine();

            var user = new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            _unitOfWork.UserService.AddWithRole(user, RoleName.Administrator);

            System.Console.WriteLine(">>>> User created with id '{0}'", user.Id);
        }
    }
}