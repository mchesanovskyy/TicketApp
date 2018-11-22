using System;
using System.Linq;
using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class EditUser : ICommand
    {
        private readonly ServicesUnitOfWork _unitOfWork;
        public EditUser(ServicesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string CommandKey
        {
            get { return "users edit"; }
        }

        public string Description
        {
            get { return "Edit user by id. Format 'users edit {id}' Example: users edit 4."; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var idStr = enteredCommandKey.Replace(CommandKey, string.Empty).Trim();
            var id = Convert.ToInt32(idStr);

            var user = _unitOfWork.UserService.Collection.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception($"User with id '{id}' doesn't exist");
            }

            System.Console.Write("Please enter new FirstName(empty to skip): ");
            var firstName = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(firstName))
            {
                user.FirstName = firstName;
            }

            System.Console.Write("Please enter new LastName(empty to skip): ");
            var lastName = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName))
            {
                user.LastName = lastName;
            }

            System.Console.Write("Please enter new Email(empty to skip): ");
            var email = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                user.Email = email;
            }

            System.Console.Write("Please enter new Password(empty to skip): ");
            var pass = System.Console.ReadLine();
            if (!string.IsNullOrEmpty(pass))
            {
                user.Password = pass;
            }

            _unitOfWork.UserService.Update(user);
        }
    }
}