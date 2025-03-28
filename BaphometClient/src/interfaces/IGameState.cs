using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src;

public interface IGameState
{
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
    void Draw(GameTime gameTime, Color tint);
    void Remove();
}
