using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFarm.Core;


namespace MyFarm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private GameState _gameState; // 游戏状态对象

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1280;// 设置窗口宽度
        _graphics.PreferredBackBufferHeight = 720;// 设置窗口高度

        Window.Title = "桃源乡"; // 设置窗口标题

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _gameState = new GameState(); // 初始化游戏状态对象

        Console.WriteLine("桃源乡启动");
        Console.WriteLine($"玩家: {_gameState.Player.Name}");
        Console.WriteLine($"铜钱: {_gameState.Player.Stats.Money}");
        Console.WriteLine($"耐力: {_gameState.Player.Stats.Stamina}/{_gameState.Player.Stats.MaxStamina}");
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // 将背景从蓝色变成绿色
        GraphicsDevice.Clear(Color.ForestGreen);

        base.Draw(gameTime);
        // TODO: Add your drawing code here

  
    }
}
