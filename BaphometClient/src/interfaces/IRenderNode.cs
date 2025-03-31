using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src.Interfaces;

public interface IRenderNode
{
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
    void Draw(GameTime gameTime, Color tint);
    // sprite interface get method
    string Name { get; set; }
    bool IsAssetOfType(Type type);
}
