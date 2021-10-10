using Flunt.Notifications;

namespace PaymentContext.Shared.ValueObjects
{
    /*
     * The instructor creates an abstract - but empty - class in order to make sure all the ValuObjects accross the project are sharing one single type.
     * 
     * This also helps because  VS Code and Visual Studio have a built-in "reference checking" feature, that makes ridiculously easy to know where
     * a property or class is being used to know beforehand where we would impact when making a change.
     */
    public abstract class ValueObject : Notifiable<Notification>
    {

    }
}
