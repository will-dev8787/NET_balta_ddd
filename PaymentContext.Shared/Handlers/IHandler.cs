using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    /*
     * IHandler<T> where T : ICommand
     * 
     * This sentence means that whatever concrete type that implements this interface, must ALSO implement ICommand.
     * This means that the Handler can only manipulate an object that is a Command.
     */
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
