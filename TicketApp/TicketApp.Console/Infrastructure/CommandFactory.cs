using System;
using System.Linq;
using TicketApp.Console.Infrastructure.Commands;
using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure
{
    public static class CommandFactory
    {
        /// <summary>
        /// This method returns a command by specified key OR null if there is no such command
        /// </summary>
        /// <param name="key">CommandKey</param>
        /// <returns>Command by selected key</returns>
        public static ICommand ResolveCommand(string key)
        {
            return Commands.FirstOrDefault(c => key.StartsWith(c.CommandKey, StringComparison.OrdinalIgnoreCase));
        }

        private static ICommand[] _commands;
        private static ICommand[] Commands
        {
            get
            {
                if (_commands == null)
                {
                    // it runs once with first call
                    var unitOfWork = new ServicesUnitOfWork();
                    _commands = GetCommands(unitOfWork);
                }

                return _commands;
            }
        }

        private static ICommand[] GetCommands(ServicesUnitOfWork unitOfWork)
        {
            var helpCommand = new HelpCommand();
            var commands = new ICommand[]
            {
                helpCommand,
                new AddAdministratorCommand(unitOfWork),
                new CloseAppCommand(),
                new ViewUsers(unitOfWork),
                new ViewAdministrators(unitOfWork),
                new EditUser(unitOfWork),
                new ReleaseTickets(unitOfWork),
            };
            helpCommand.SetCommands(commands);
            return commands;
        }
    }
}