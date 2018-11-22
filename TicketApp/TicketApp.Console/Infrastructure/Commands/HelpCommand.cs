using System.Linq;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class HelpCommand : ICommand
    {
        private ICommand[] _commands;

        public string CommandKey
        {
            get { return "help"; }
        }

        public string Description
        {
            get { return "Display available commands"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            if (_commands == null || !_commands.Any())
            {
                System.Console.WriteLine("No commands");
                return;
            }

            var longestKeyLength = _commands.Max(c => c.CommandKey.Length);
            foreach (var command in _commands)
            {
                System.Console.WriteLine("{0} - {1}", command.CommandKey.PadRight(longestKeyLength), command.Description);
            }
        }

        public void SetCommands(ICommand[] commands)
        {
            _commands = commands;
        }
    }
}