using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship.Input;

internal class GamePadInputHandler : IInputActionHandler
{
    private GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
    private readonly Dictionary<InputActions, List<Buttons>> inputActionsMapping = new()
    {
        { InputActions.MoveUp, [Buttons.DPadUp] },
        { InputActions.MoveDown, [Buttons.DPadDown] },
        { InputActions.MoveLeft, [Buttons.DPadLeft] },
        { InputActions.MoveRight, [Buttons.DPadRight] },
        { InputActions.StartGame, [Buttons.A] },
        { InputActions.ExitGame, [Buttons.Back] },
    };

    private List<Buttons> GetPressedButtons()
    {
        List<Buttons> pressedButtons = [];

        foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
        {
            if (gamePadState.IsButtonDown(button))
            {
                pressedButtons.Add(button);
            }
        }

        return pressedButtons;
    }

    public bool IsExecutingAction(InputActions inputAction) {
        List<Buttons> inputActionButtons = inputActionsMapping[inputAction];

        List<Buttons> pressedButtons = GetPressedButtons();

        return pressedButtons.Intersect(inputActionButtons).Any();
    }
}
