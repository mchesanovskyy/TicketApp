using System;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class CloseAppCommand : ICommand
    {
        public string CommandKey
        {
            get { return "exit"; }
        }

        public string Description
        {
            get { return "Close program"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            Environment.Exit(0);
        }
    }
}