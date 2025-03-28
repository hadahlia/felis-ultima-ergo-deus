using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Baphomet.Src;

public class UI
{
    public class UIPropertyBase : IUIProperty
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public Color Color { get; set; }
        public Color OutlineColor { get; set; }
        public Color HoverColor { get; set; }
        public bool Hovering { get; set; }
        public string Name { get; set; }
        protected Texture2D _controlTex {  get; set; }
        protected string _controlTexName;

        public string ControlTexture
        {
            get
            {
                return _controlTexName;
            }
            set
            {
                //_controlTex =
                _controlTexName = value;
            }
        }

        protected void DrawString(SpriteFont font, string text, Rectangle bounds,AlignmentEnum align, Color color)
        {
            Vector2 size = font.MeasureString(text);
            Point pos = bounds.Center;
            Vector2 origin = size * 0.5f;

            if (align.HasFlag(AlignmentEnum.Left))
            {
                origin.X += bounds.Width / 2 - size.X / 2;
            }

            if (align.HasFlag(AlignmentEnum.Right))
            {
                origin.X -= bounds.Width / 2 - size.X / 2;
            }

            if (align.HasFlag(AlignmentEnum.Top))
            {
                origin.Y += bounds.Height / 2 - size.Y / 2;
            }
            if (align.HasFlag(AlignmentEnum.Bottom))
            {
                origin.Y -= bounds.Height / 2 - size.Y / 2;
            }

            Engine.SpriteBatch.DrawString(font, text, new Vector2(pos.X, pos.Y), color, 0, origin, 1, SpriteEffects.None, 0);
        }

    }


    public enum AlignmentEnum
    {
        Center = 0,
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8
    }
    public class Button : UIPropertyBase, IRenderNode
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color HoverTextColor { get; set; }
        private SpriteFont _font;
        private IButtonHandler _handler;

        public Button(string name, IButtonHandler handler)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            _handler = handler;
            Name = name;
            Width = 50;
            Height = 20;
            Position = new Vector2(100, 100);
            Enabled = true;
            Visible = true;
            Text = "Unimplemented Button";
            Color = Color.Blue;
            OutlineColor = Color.Black;
            HoverColor = Color.Red;
            TextColor = Color.Black;
            HoverTextColor = Color.White;

            _font = Engine.Content.Load<SpriteFont>("default");
        }

        public void Update(GameTime gameTime)
        {
            Rectangle bounds = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            //var mouse = screen to world?
        }

        public void Draw(GameTime gameTime)
        {
            Draw(gameTime, Color.White);
        }

        public void Draw(GameTime gameTime, Color tint)
        {
            if (!Visible)
            {
                return;
            }

            if (!string.IsNullOrEmpty(_controlTexName))
            {
                if (Hovering)
                {
                    Engine.SpriteBatch.Draw(_controlTex, Position,
                        new Rectangle(0,0, _controlTex.Width, _controlTex.Height), HoverTextColor, 0.0f,
                        new Vector2(0,0), 1.0f, SpriteEffects.None, 0.0f);
                } else
                {
                    Engine.SpriteBatch.Draw(_controlTex, Position, 
                        new Rectangle(0, 0, _controlTex.Width, _controlTex.Height), Color.White, 0.0f,
                        new Vector2(0,0), 1.0f, SpriteEffects.None, 0.0f);
                }
            }
        }

        public ISprite GetSprite()
        {
            throw new NotImplementedException();
        }

        public bool IsAssetOfType(Type type)
        {
            return GetType() == type;
        }

    }
}
