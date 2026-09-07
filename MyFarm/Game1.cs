using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyFarm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _playerTexture;
    private Vector2 _playerPosition;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _playerPosition = new Vector2(300, 200);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _playerTexture = new Texture2D(GraphicsDevice, 1, 1);
        _playerTexture.SetData(new[] { Color.White });

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
        // 将背景从蓝色变成绿色
        GraphicsDevice.Clear(Color.ForestGreen);

        _spriteBatch.Begin();

        _spriteBatch.Draw(
            _playerTexture,
              new Rectangle(
            (int)_playerPosition.X,
            (int)_playerPosition.Y,
            40,
            60
        ),
        Color.White
    );

        _spriteBatch.End();

        base.Draw(gameTime);
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
