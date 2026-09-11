using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFarm.Characters;




namespace MyFarm;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player ; // 玩家对象
    private TileMap _tileMap; // 地图对象

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
        // 创建地图对象
        _tileMap = new TileMap();

        // 创建玩家对象
        _player = new Player();
        base.Initialize();
       
    }

    protected override void LoadContent()
    {
        
        // TODO: use this.Content to load your game content here
        // SpriteBatch 是 MonoGame 中用来批量绘制 2D 图形的工具
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // 让地图创建自己的绘制纹理
        _tileMap.LoadContent(GraphicsDevice);
        // 让玩家创建自己的绘制纹理
        _player.LoadContent(GraphicsDevice); 
        

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here
        _player.Update(gameTime, GraphicsDevice);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        // 每一帧开始前，先清空屏幕为黑色
        GraphicsDevice.Clear(Color.Black);

        // 开始这一帧的绘制
        _spriteBatch.Begin();

        // 绘制地图
        _tileMap.Draw(_spriteBatch);

        // 绘制玩家
        _player.Draw(_spriteBatch);

        // 结束这一帧的绘制
        _spriteBatch.End();


        base.Draw(gameTime);


  
    }
}
