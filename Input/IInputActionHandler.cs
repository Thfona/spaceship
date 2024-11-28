namespace Spaceship.Input;

internal interface IInputActionHandler
{
    public bool IsExecutingAction(InputActions inputAction);
}
