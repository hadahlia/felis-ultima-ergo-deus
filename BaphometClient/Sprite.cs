using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baphomet
{
    internal class Sprite
    {
        public Texture2D _tex;
        public Vector2 _pos;

        public Sprite(Texture2D _tex, Vector2 _pos)
        {
            this._tex = _tex;
            this._pos = _pos;
        }
    }

    internal class ScaledSprite : Sprite
    {
        public Rectangle Quad
        {
            get
            {
                return new Rectangle((int)_pos.X, (int)_pos.Y, 64, 64);
            }
        }

        public ScaledSprite(Texture2D _tex, Vector2 _position) : base(_tex, _position)
        {

        }
    }
}
