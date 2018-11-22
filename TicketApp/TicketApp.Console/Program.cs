using System;
using System.Linq;
using TicketApp.Console.Infrastructure;
using TicketApp.Core.Services;

namespace TicketApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Write("Please enter command: ");
                var enteredCommandKey = System.Console.ReadLine();
                if(enteredCommandKey == null)
                    continue;

                var command = CommandFactory.ResolveCommand(enteredCommandKey);
                if (command == null)
                {
                    System.Console.WriteLine("Command doesn't found");
                    continue;
                }

                try
                {
                    command.Execute(args, enteredCommandKey);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
        }
    }
}
