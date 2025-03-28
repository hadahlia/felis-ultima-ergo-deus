using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Baphomet;

public static class Engine
{
    public static GraphicsDeviceManager GraphicsDevice;

    public static Point WindowSize;

    public static Matrix SpriteScale;
    public static SpriteBatch SpriteBatch;

    private static Game _game;

    public static Vector2 _scaledViewPort;
    public static Matrix _spriteScaleFactor;
    //public static GameState
    public static void InitCore(Game game, int windowX, int windowY)
    {
        _game = game;
        GraphicsDevice = new GraphicsDeviceManager(game);
        game.Content.RootDirectory = "Content";

        game.IsMouseVisible = true;

        WindowSize = new Point(windowX, windowY);
        Fullscreen = false;
        SpriteBatch = new SpriteBatch(_game.GraphicsDevice);
    }

    public static void InitCore(Game game)
    {
        InitCore(game, 2560, 1080);
    }

    public static ContentManager Content => _game.Content;

    //scene instancing?

    public static void Exit()
    {
        _game.Exit();
    }

    public static void BeginRender()
    {
        SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
    }

    public static void EndRender()
    {
        SpriteBatch.End();
    }

    public static void ApplyResolutionSettings(bool fullScreen)
    {
        GraphicsDevice.IsFullScreen = fullScreen;

        Point screenSize = fullScreen
            ? new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height)
            : WindowSize;

        GraphicsDevice.PreferredBackBufferWidth = screenSize.X;
        GraphicsDevice.PreferredBackBufferHeight = screenSize.Y;

        GraphicsDevice.ApplyChanges();

        _game.GraphicsDevice.Viewport = CalculateViewport(screenSize);
    }

    public static Viewport CalculateViewport(Point windowSize)
    {
        Viewport viewport = new Viewport();
        //float gameAspectRatio
        float windowAspectRatio = (float)windowSize.X / (float)windowSize.Y;
        //check whether window is high or wide, and compensate
        
        viewport.X = (windowSize.X * viewport.Width) / 2;
        viewport.Y = (windowSize.Y * viewport.Height) / 2;

        return viewport;
    }

    public static bool Fullscreen
    {
        get => GraphicsDevice.IsFullScreen;
        set => ApplyResolutionSettings(value);
    }

}
