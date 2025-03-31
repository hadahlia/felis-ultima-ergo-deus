using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src.Interfaces;

public interface ISprite : IRenderNode
{
    bool isVisible { get; set; }
    bool isEnabled { get; set; }
    bool RenderBoundingBox { get; set; }
    float X { get; set; }
    float Y { get; set; }
    float VX { get; set; }
    float VY { get; set; }
    bool Flip { get; set; }
    Vector2 Position { get; set; }
    Vector2 Velocity { get; set; }
    int Height { get; set; }
    int Width { get; set; }
    Rectangle Dimensions { get; set; }
    Rectangle BoundingBox { get; set; }
    void LoadContent(string textureName);
    bool CollidesWith(ISprite sprite);
}
