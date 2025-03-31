using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using System.Security.Principal;

using Baphomet.Src;
using Baphomet.Src.Shapes;
using System.Linq.Expressions;

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

    public IsoTiles tile;

    public Texture2D circleTexture;

    //temp geometry info
    private VertexPositionColor[] primitiveVerts;
    private short[] primIndices;
    //private VertexPositionColorTexture[] tingleArrayTest;
    //private short[] tingleIndicesArray;
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
        cammy = new OrthoCamera(25, 25);
        //cammy.ViewportWidth = GraphicsDevice.Viewport.Width;
        //cammy.ViewportHeight = GraphicsDevice.Viewport.Height;
        //_cursorTex = Engine.Content.Load<Texture2D>("gui/cursor");
        //_crosshair = new Sprite(_cursorTex, Vector2.Zero);
        //basic effect
        basicEffect = new BasicEffect(GraphicsDevice);
        basicEffect.Alpha = 1.0f;
        basicEffect.VertexColorEnabled = true;
        basicEffect.LightingEnabled = false;
        //basicEffect.TextureEnabled = true;

        //circleTexture = Shapes.CreateCircle(GraphicsDevice, 160, Color.White);

        //basicEffect.Texture = circleTexture;

        Vector3 FrontBottomLeft = new Vector3(-2f, -1f, -2f); // GREEN
        Vector3 FrontBottomRight = new Vector3(2f, -1f, -2f); // BLUE
        Vector3 FrontTopRight = new Vector3(2f, 1f, -2f); // WHITE
        Vector3 FrontTopLeft = new Vector3(-2f, 1f, -2f); // RED
        Vector3 BackTopLeft = new Vector3(-2,1f,2f); // YELLOW 
        Vector3 BackTopRight = new Vector3(2f,1f,2f); // PURPLE
        Vector3 BackBottomRight = new Vector3(2f, -1f, 2f); // BROWN

        primitiveVerts = new VertexPositionColor[7];

        primitiveVerts[0] = new VertexPositionColor(FrontBottomLeft, Color.Green);
        primitiveVerts[1] = new VertexPositionColor(FrontBottomRight, Color.Blue);
        primitiveVerts[2] = new VertexPositionColor(FrontTopRight, Color.White);
        primitiveVerts[3] = new VertexPositionColor(FrontTopLeft, Color.Red);
        primitiveVerts[4] = new VertexPositionColor(BackTopLeft, Color.Yellow);
        primitiveVerts[5] = new VertexPositionColor(BackTopRight, Color.Purple);
        primitiveVerts[6] = new VertexPositionColor(BackBottomRight, Color.Brown);

        //front face
        //primitiveVerts[0] = new VertexPositionColor(FrontBottomLeft, Color.Green); //bleft
        //primitiveVerts[1] = new VertexPositionColor(FrontTopRight, Color.White); //tright
        //primitiveVerts[2] = new VertexPositionColor(FrontTopLeft, Color.Red); //tright

        //primitiveVerts[3] = new VertexPositionColor(FrontBottomLeft, Color.Green); //tleft
        //primitiveVerts[4] = new VertexPositionColor(FrontBottomRight, Color.Blue);
        //primitiveVerts[5] = new VertexPositionColor(FrontTopRight, Color.White);

        //right face
        //primitiveVerts[6] = new VertexPositionColor(FrontBottomRight, Color.Blue); //bright
        //primitiveVerts[7] = new VertexPositionColor(BackTopRight, Color.Purple); //tright
        //primitiveVerts[8] = new VertexPositionColor(FrontTopRight, Color.White); //tleft

        //primitiveVerts[9] = new VertexPositionColor(FrontBottomRight, Color.Blue);
        //primitiveVerts[10] = new VertexPositionColor(BackBottomRight, Color.Brown);
        //primitiveVerts[11] = new VertexPositionColor(BackTopRight, Color.Purple);

        //top face

        //primitiveVerts[12] = new VertexPositionColor(FrontTopLeft, Color.Red);
        //primitiveVerts[13] = new VertexPositionColor(BackTopRight, Color.Purple);
        //primitiveVerts[14] = new VertexPositionColor(BackTopLeft, Color.Yellow);

        //primitiveVerts[15] = new VertexPositionColor(FrontTopLeft, Color.Red);
        //primitiveVerts[16] = new VertexPositionColor(FrontTopRight, Color.White);
        //primitiveVerts[17] = new VertexPositionColor(BackTopRight, Color.Purple);

        //well how abt a triangle? pretty please

        //@TODO this tingle array could be repurposed as player
        //tingleArrayTest = new VertexPositionColorTexture[6];

        //tingleArrayTest[0] = new VertexPositionColorTexture(new Vector3(-80f,80f,0f), Color.Red, new Vector2(0f, -1f)); //top left
        //tingleArrayTest[1] = new VertexPositionColorTexture(new Vector3(-80f, -80f, 0f), Color.Green, new Vector2(0f,0f)); //bottom left
        //tingleArrayTest[2] = new VertexPositionColorTexture(new Vector3(80f, -80f, 0f), Color.Blue, new Vector2(1f,0f)); //bottom right

        //tingleArrayTest[3] = new VertexPositionColorTexture(new Vector3(80f, 80f, 0f), Color.AntiqueWhite, new Vector2(1f, -1f)); // top right
        //tingleArrayTest[4] = new VertexPositionColorTexture(new Vector3(-80f, 80f, 0f), Color.Red, new Vector2(0f,-1f)); // top left
        //tingleArrayTest[5] = new VertexPositionColorTexture(new Vector3(80f, -80f, 0f), Color.Blue, new Vector2(1f,0f)); // bottom right

        vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), primitiveVerts.Length, BufferUsage.WriteOnly);
        vertexBuffer.SetData<VertexPositionColor>(primitiveVerts);

        //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColorTexture), 6, BufferUsage.WriteOnly);
        //vertexBuffer.SetData<VertexPositionColorTexture>(tingleArrayTest);

        //indices shit

        primIndices = new short[18];

        //front face
        primIndices[0] = 0;
        primIndices[1] = 2;
        primIndices[2] = 3;
        primIndices[3] = 0;
        primIndices[4] = 1;
        primIndices[5] = 2;

        //right face
        primIndices[6] = 1;
        primIndices[7] = 5;
        primIndices[8] = 2;
        primIndices[9] = 1;
        primIndices[10] = 6;
        primIndices[11] = 5;

        //top face
        primIndices[12] = 3;
        primIndices[13] = 5;
        primIndices[14] = 4;
        primIndices[15] = 3;
        primIndices[16] = 2;
        primIndices[17] = 5;
        //primIndices[12] = 2;
        //primIndices[13] = 5;
        //primIndices[14] = 6;
        //primIndices[15] = 6;
        //primIndices[16] = 3;
        //primIndices[17] = 2;

        indexBuffer = new IndexBuffer(GraphicsDevice, typeof(short), primIndices.Length, BufferUsage.WriteOnly);
        indexBuffer.SetData<short>(primIndices);

        //tingleIndicesArray = new short[6];

        //tingleIndicesArray[0] = 0;
        //tingleIndicesArray[1] = 3;
        //tingleIndicesArray[2] = 2;

        //tingleIndicesArray[3] = 1;
        //tingleIndicesArray[4] = 0;
        //tingleIndicesArray[5] = 2;

        //indexBuffer = new IndexBuffer(GraphicsDevice, typeof(short), tingleIndicesArray.Length, BufferUsage.WriteOnly);
        //indexBuffer.SetData<short>(tingleIndicesArray);

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

        //var t2 = Matrix.CreateTranslation(0f, 0f, 0f);
        //var r1 = Matrix.CreateRotationX(0f);
        //var r2 = Matrix.CreateRotationY(0f);
        //var r3 = Matrix.CreateRotationZ(0f);
        //var s = Matrix.CreateScale(1f);
        //basicEffect.World = r1 * r2 * r3 * s * t2;

        basicEffect.Projection = cammy.ProjectionMatrix;
        
        basicEffect.World = cammy.WorldMatrix;
        basicEffect.View = cammy.ViewMatrix;
        //basicEffect.


        //GraphicsDevice.Textures[0] = circleTexture;

        RasterizerState rasterState = new RasterizerState();
        rasterState.CullMode = CullMode.None;
        GraphicsDevice.RasterizerState = rasterState;
        GraphicsDevice.BlendState = BlendState.AlphaBlend;

        

        GraphicsDevice.Clear(Color.CornflowerBlue);

        foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            //GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 2);
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 6);
            //GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, 6, 1);
            //GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
            //    PrimitiveType.TriangleList,
            //    primitiveVerts,
            //    0,
            //    18,
            //    primIndices,
            //    0,
            //    6
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

