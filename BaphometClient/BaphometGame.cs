using Baphomet.Src;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using System.Security.Principal;

namespace Baphomet;

public class BaphometGame : Game
{
    //private GraphicsDeviceManager _graphics;
    //private SpriteBatch _spriteBatch;

    ////Texture2D _texture;
    //ScaledSprite p_sprite;
    //ScaledSprite t_sprite;

    public OrthoCamera cammy;

    public BasicEffect basicEffect;

    public Texture2D _cursorTex;
    private readonly Sprite _crosshair;

    public IsoTile tile;

    //temp geometry info
    private VertexPositionColor[] primitiveVerts;
    private VertexPositionColor[] tingleArrayTest;
    private VertexBuffer vertexBuffer;
    //public IndexBuffer indexBuffer;

    public BaphometGame()
    {
        Engine.InitCore(this, 1280, 720);
        //_graphics = new GraphicsDeviceManager(this);
        //Content.RootDirectory = "Content";
        IsMouseVisible = true;

    }

    protected override void Initialize()
    {
        base.Initialize();
        // TODO: Add your initialization logic here
        //Globals.Camera.ViewportWidth = _graphics.GraphicsDevice.Viewport.Width;
        //Globals.Camera.ViewportHeight = _graphics.GraphicsDevice.Viewport.Height;
        cammy = new OrthoCamera();
        cammy.ViewportWidth = GraphicsDevice.Viewport.Width;
        cammy.ViewportHeight = GraphicsDevice.Viewport.Height;
        //_cursorTex = Engine.Content.Load<Texture2D>("gui/cursor");
        //_crosshair = new Sprite(_cursorTex, Vector2.Zero);
        //basic effect
        basicEffect = new BasicEffect(GraphicsDevice);
        basicEffect.Alpha = 1.0f;
        basicEffect.VertexColorEnabled = true;
        basicEffect.LightingEnabled = false;

        //primitive verts
        //primitiveVerts = new VertexPositionColor[4];
        ////top face
        //primitiveVerts[0] = new VertexPositionColor(new Vector3(-0.57143f, 0.17143f, -0.42857f), Color.Red);
        //primitiveVerts[1] = new VertexPositionColor(new Vector3(-0.57143f, 0.17143f, 0.57143f ), Color.Green);
        //primitiveVerts[2] = new VertexPositionColor(new Vector3(0.42857f, 0.17143f, -0.42857f), Color.Blue);
        //primitiveVerts[3] = new VertexPositionColor(new Vector3(0.42857f, 0.17143f, 0.57143f ), Color.Azure);
        //left face
        //right face

        //well how abt a triangle? pretty please
        tingleArrayTest = new VertexPositionColor[3];

        tingleArrayTest[0] = new VertexPositionColor(new Vector3(0f,40f,0f), Color.Red);
        tingleArrayTest[1] = new VertexPositionColor(new Vector3(-40f, -40f, 0f), Color.Green);
        tingleArrayTest[2] = new VertexPositionColor(new Vector3(40f, -40f, 0f), Color.Blue);

        //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 4, BufferUsage.WriteOnly);
        //vertexBuffer.SetData<VertexPositionColor>(primitiveVerts);
        vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
        vertexBuffer.SetData<VertexPositionColor>(tingleArrayTest);

        //indexBuffer = new IndexBuffer(GraphicsDevice, typeof(IndexBuffer), 6, BufferUsage.WriteOnly);

        
    }

        protected override void LoadContent()
        {
            //tile = new IsoTile();
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            //_texture = Content.Load<Texture2D>("entity/player_static");

            //Texture2D player_texture = Content.Load<Texture2D>("entity/player_static");
            //Texture2D tile_texture = Content.Load<Texture2D>("tile/tile_0");
            //p_sprite = new ScaledSprite(player_texture, Vector2.Zero);
            //t_sprite = new ScaledSprite(tile_texture, Vector2.One);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

    protected override void Draw(GameTime gameTime)
    {
        basicEffect.Projection = cammy.ProjectionMatrix;
        basicEffect.View = cammy.ViewMatrix;
        basicEffect.World = cammy.WorldMatrix;

        GraphicsDevice.Clear(Color.Black);
        GraphicsDevice.SetVertexBuffer(vertexBuffer);


        RasterizerState rasterState = new RasterizerState();
        rasterState.CullMode = CullMode.None;
        GraphicsDevice.RasterizerState = rasterState;

        

        foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
        }

        // TODO: Add your drawing code here
        //_spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);

        //_spriteBatch.Draw(t_sprite._tex, t_sprite.Quad, Color.White);
        //_spriteBatch.Draw(p_sprite._tex, p_sprite.Quad, Color.White);
        //Engine.BeginRender();
        //_spriteBatch.End();

        //tile.Draw(cammy.ViewMatrix, cammy.ProjectionMatrix);
        
        //Engine.EndRender();

        base.Draw(gameTime);
    }
}

