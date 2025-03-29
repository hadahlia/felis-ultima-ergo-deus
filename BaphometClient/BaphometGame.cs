using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using System.Security.Principal;

using Baphomet.Src;
using Baphomet.Src.Shapes;

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

    public Texture2D circleTexture;

    //temp geometry info
    private VertexPositionColor[] primitiveVerts;
    private VertexPositionColorTexture[] tingleArrayTest;
    private short[] tingleIndicesArray;
    private VertexBuffer vertexBuffer;
    public IndexBuffer indexBuffer;

    public BaphometGame()
    {
        Engine.InitCore(this, 640, 480);
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
        basicEffect.TextureEnabled = true;

        circleTexture = Shapes.CreateCircle(GraphicsDevice, 160, Color.White);

        basicEffect.Texture = circleTexture;

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
        tingleArrayTest = new VertexPositionColorTexture[6];

        tingleArrayTest[0] = new VertexPositionColorTexture(new Vector3(-80f,80f,0f), Color.Red, new Vector2(0f, -1f)); //top left
        tingleArrayTest[1] = new VertexPositionColorTexture(new Vector3(-80f, -80f, 0f), Color.Green, new Vector2(0f,0f)); //bottom left
        tingleArrayTest[2] = new VertexPositionColorTexture(new Vector3(80f, -80f, 0f), Color.Blue, new Vector2(1f,0f)); //bottom right

        tingleArrayTest[3] = new VertexPositionColorTexture(new Vector3(80f, 80f, 0f), Color.AntiqueWhite, new Vector2(1f, -1f)); // top right
        tingleArrayTest[4] = new VertexPositionColorTexture(new Vector3(-80f, 80f, 0f), Color.Red, new Vector2(0f,-1f)); // top left
        tingleArrayTest[5] = new VertexPositionColorTexture(new Vector3(80f, -80f, 0f), Color.Blue, new Vector2(1f,0f)); // bottom right

        //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 4, BufferUsage.WriteOnly);
        //vertexBuffer.SetData<VertexPositionColor>(primitiveVerts);
        vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColorTexture), 6, BufferUsage.WriteOnly);
        vertexBuffer.SetData<VertexPositionColorTexture>(tingleArrayTest);

        //indices shit

        tingleIndicesArray = new short[6];

        tingleIndicesArray[0] = 0;
        tingleIndicesArray[1] = 3;
        tingleIndicesArray[2] = 2;

        tingleIndicesArray[3] = 1;
        tingleIndicesArray[4] = 0;
        tingleIndicesArray[5] = 2;

        indexBuffer = new IndexBuffer(GraphicsDevice, typeof(short), tingleIndicesArray.Length, BufferUsage.WriteOnly);
        indexBuffer.SetData<short>(tingleIndicesArray);

        GraphicsDevice.SetVertexBuffer(vertexBuffer);
        GraphicsDevice.Indices = indexBuffer;
    }

    protected override void LoadContent()
    {
        //tile = new IsoTile();
        //_spriteBatch = new SpriteBatch(GraphicsDevice);

        //_texture = Content.Load<Texture2D>("entity/player_static");
        

        //Texture2D cTexture = Engine.Content.Load<Texture2D>(circl)

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

        GraphicsDevice.Textures[0] = circleTexture;

        RasterizerState rasterState = new RasterizerState();
        rasterState.CullMode = CullMode.None;
        GraphicsDevice.RasterizerState = rasterState;
        GraphicsDevice.BlendState = BlendState.AlphaBlend;

        

        foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            //GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 2);
            //GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColorTexture>(
            //    PrimitiveType.TriangleList,
            //    tingleArrayTest,
            //    0,
            //    6,
            //    tingleIndicesArray,
            //    0,
            //    2
            //);
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

