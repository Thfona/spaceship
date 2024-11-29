using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Spaceship.Input;

internal class KeyboardInputHandler : IInputActionHandler
{
    private KeyboardState keyboardState = Keyboard.GetState();
    private readonly Dictionary<InputActions, Keys[]> inputActionsMapping = new()
    {
        { InputActions.MoveUp, [Keys.W, Keys.Up] },
        { InputActions.MoveDown, [Keys.S, Keys.Down] },
        { InputActions.MoveLeft, [Keys.A, Keys.Left] },
        { InputActions.MoveRight, [Keys.D, Keys.Right] },
        { InputActions.StartGame, [Keys.Enter] },
        { InputActions.ExitGame, [Keys.Escape] },
    };

    public bool IsExecutingAction(InputActions inputAction) {
        Keys[] inputActionKeys = inputActionsMapping[inputAction];

        Keys[] pressedKeys = keyboardState.GetPressedKeys();

        return pressedKeys.Intersect(inputActionKeys).Any();
    }
}
