using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Baphomet;

public static class InputHelper
{
    private static MouseState curMouseState, prevMouseState;

    private static KeyboardState curKeyboardState, prevKeyboardState;

    public static void Update()
    {
        prevMouseState = curMouseState;
        prevKeyboardState = curKeyboardState;
        curMouseState = Mouse.GetState();
        curKeyboardState = Keyboard.GetState();
    }

    public static Vector2 mousePosition => new Vector2(curMouseState.X, curMouseState.Y);

    public static bool MouseLeftClick()
    {
        return curMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released;
    }

    //mouse right click

    //mouse left held

    //mouse right held

    public static bool KeyPressed(Keys k)
    {
        return curKeyboardState.IsKeyDown(k) && prevKeyboardState.IsKeyUp(k);
    }
}
