using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src.Interfaces;

public interface IButton : IUIProperty
{
    string Text { get; set; }
    Color TextColor { get; set; }
    Color HoverTextColor { get; set; }
}
