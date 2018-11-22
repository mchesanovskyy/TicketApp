namespace TicketApp.Console.Infrastructure
{
    public interface ICommand
    {
        string CommandKey { get; }
        string Description { get; }
        void Execute(string[] args, string enteredCommandKey);
    }
}