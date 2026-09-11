using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
namespace MyFarm.Characters;

public class Player
{
    private Texture2D _playerTexture;// 玩家纹理
    private Vector2 _playerPosition;// 玩家位置
    private float _playerSpeed = 200f;// 玩家移动速度
    private int _playerWidth = 40; // 玩家宽度
    private int _playerHeight = 60;// 玩家高度

    //创建构造函数
    public Player()
    {
        _playerPosition = new Vector2(100, 100); // 初始化玩家位置

    }

    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        // 创建一个简单的玩家纹理（白色矩形）
        _playerTexture = new Texture2D(graphicsDevice, _playerWidth, _playerHeight);
        Color[] data = new Color[_playerWidth * _playerHeight];
        for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
        _playerTexture.SetData(data);
    }

    public void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        float deltaTime =
            (float)gameTime.ElapsedGameTime.TotalSeconds;

        Vector2 direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W))
        {
            direction.Y -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.S))
        {
            direction.Y += 1;
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            direction.X -= 1;
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            direction.X += 1;
        }

        if (direction.LengthSquared() > 0)
        {
            direction.Normalize();
        }

        _playerPosition += direction * _playerSpeed * deltaTime;

        _playerPosition.X = MathHelper.Clamp(
            _playerPosition.X,
            0,
            graphicsDevice.Viewport.Width - _playerWidth
        );

        _playerPosition.Y = MathHelper.Clamp(
            _playerPosition.Y,
            0,
            graphicsDevice.Viewport.Height - _playerHeight
        );
    }

    public void Draw(SpriteBatch spriteBatch)
    {
         spriteBatch.Draw(
        _playerTexture,
        new Rectangle(
            (int)_playerPosition.X,
            (int)_playerPosition.Y,
            _playerWidth,
            _playerHeight
        ),
        Color.White
    );
    }
    
}