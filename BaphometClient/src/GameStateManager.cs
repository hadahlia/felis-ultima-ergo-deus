using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Xna.Framework;

using Baphomet.Src.Interfaces;

namespace Baphomet;

public class GameStateManager
{
    private readonly Dictionary<string, IGameState> registeredGameStates = new Dictionary<string, IGameState>();

    public GameStateManager()
    {

    }

    public IGameState CurrentState { get; private set; } = null;
    public IGameState PreviousState { get; private set; } = null;

    public void Register(string name, IGameState gameState)
    {
        if(string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        if (gameState == null) throw new ArgumentNullException(nameof(gameState));

        if (registeredGameStates.ContainsKey(name.ToUpper(CultureInfo.InvariantCulture)))
        {
            registeredGameStates.Remove(name.ToUpper(CultureInfo.InvariantCulture));
        }

        registeredGameStates.Add(name.ToUpper(CultureInfo.InvariantCulture), gameState);
    }

    public void DropState(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        if(!registeredGameStates.ContainsKey(name.ToUpper(CultureInfo.InvariantCulture)))
        {
            throw new InvalidOperationException("gamestate dictionary contains no entry for <" + name + ">");
        }

        registeredGameStates.Remove(name.ToUpper(CultureInfo.InvariantCulture));
    }

    public void ChangeState(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        if (!registeredGameStates.ContainsKey(name.ToUpper(CultureInfo.InvariantCulture)))
        {
            throw new InvalidOperationException("gamestate dictionary contains no entry for <" + name + ">");
        }

        PreviousState = CurrentState;
        CurrentState = registeredGameStates[name.ToUpper(CultureInfo.InvariantCulture)];
    }
}
