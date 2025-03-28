using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src;

public interface IUIProperty
{
    int Width { get; set; }
    int Height { get; set; }
    Vector2 Position { get; set; }
    bool Enabled { get; set; }
    bool Visible { get; set; }
    Color Color { get; set; }
    Color OutlineColor { get; set; }
    Color HoverColor { get; set; }
    bool Hovering { get; }
}
