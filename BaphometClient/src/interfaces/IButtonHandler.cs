using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet.Src.Interfaces;

public interface IButtonHandler
{
    void OnMouseClick(UI.UIPropertyBase checkBox);
    void OnMouseHover(UI.UIPropertyBase checkBox);
    void OnCheck(UI.UIPropertyBase checkBox);
}
