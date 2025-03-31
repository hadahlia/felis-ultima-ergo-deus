using Microsoft.Xna.Framework;

namespace Baphomet.Src.Interfaces;

public interface IGameState
{
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
    void Draw(GameTime gameTime, Color tint);
    void Remove();
}
