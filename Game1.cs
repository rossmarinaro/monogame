using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace testGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D testTex;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    public void OnResize(Object sender, EventArgs e)
    {
        if ((_graphics.PreferredBackBufferWidth != _graphics.GraphicsDevice.Viewport.Width) ||
            (_graphics.PreferredBackBufferHeight != _graphics.GraphicsDevice.Viewport.Height))
        {
            _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Viewport.Width;
            _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Viewport.Height;
            _graphics.ApplyChanges();

           // States[_currentState].Rearrange();
        }
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnResize;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        using (var fileStream = new FileStream("Content/swanky_bubble.png", FileMode.Open))
        {
            testTex = Texture2D.FromStream(GraphicsDevice, fileStream);
        }
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
        GraphicsDevice.Clear(new Color(new Vector4(0.0f, 0.0f, 0.0f, 1)));

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        _spriteBatch.Draw(testTex, new Vector2(0, 0), new Color(new Vector4(1, 1, 1, 1)));

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
