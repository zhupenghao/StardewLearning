using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFarm;

// TileMap 负责保存和绘制游戏地图。
public class TileMap
{
    // 每一个地图格子的尺寸。
    // 当前一个 Tile = 32 × 32 像素。
    private int _tileSize = 32;

    // 地图横向有多少列。
    private int _columns = 25;

    // 地图纵向有多少行。
    private int _rows = 15;

    // 用来绘制 Tile 的基础纹理。
    // 当前我们不用 PNG，而是创建一个 1 × 1 的白色纹理。
    private Texture2D _tileTexture;

    // 二维数组用于保存整个地图的数据。
    //
    // int[,] 表示“二维整数数组”。
    //
    // 我们当前规定：
    // 0 = 草地
    // 1 = 土地
    //
    // 使用方式：
    // _tiles[行, 列]
    private int[,] _tiles;


    // 构造函数。
    // 当执行 new TileMap() 时自动运行。
    public TileMap()
    {
        // 创建地图二维数组。
        //
        // 行数 = _rows
        // 列数 = _columns
        //
        // 所以当前地图是：
        // 15 行 × 25 列
        _tiles = new int[_rows, _columns];

        // C# 创建 int 数组后，
        // 所有元素默认都是 0。
        //
        // 因为我们规定：
        // 0 = 草地
        //
        // 所以整个地图默认都是草地。


        // 手动创建一小块土地。
        //
        // 注意：
        // _tiles[row, column]
        //
        // 第一个数字是“行”
        // 第二个数字是“列”

        _tiles[5, 8] = 1;
        _tiles[5, 9] = 1;

        _tiles[6, 8] = 1;
        _tiles[6, 9] = 1;
    }


    // 创建地图绘制需要的纹理。
    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        // 创建一个 1 × 1 像素的纹理。
        _tileTexture = new Texture2D(
            graphicsDevice,
            1,
            1
        );

        // 把唯一的像素设置为白色。
        //
        // 之后 SpriteBatch.Draw()
        // 可以通过 Color 参数把它染成不同颜色。
        _tileTexture.SetData(
            new[] { Color.White }
        );
    }


    // 绘制整个地图。
    public void Draw(SpriteBatch spriteBatch)
    {
        // 外层循环负责“行”。
        //
        // row 会依次变成：
        // 0, 1, 2, 3 ... 14
        for (int row = 0; row < _rows; row++)
        {
            // 内层循环负责“列”。
            //
            // 每一行都会从：
            // column = 0
            // 一直执行到：
            // column = 24
            for (int column = 0; column < _columns; column++)
            {
                // 根据“列”计算屏幕 X 坐标。
                //
                // 例如：
                //
                // column = 0
                // x = 0 × 32 = 0
                //
                // column = 1
                // x = 1 × 32 = 32
                //
                // column = 2
                // x = 2 × 32 = 64
                int x = column * _tileSize;


                // 根据“行”计算屏幕 Y 坐标。
                //
                // 例如：
                //
                // row = 0
                // y = 0
                //
                // row = 1
                // y = 32
                int y = row * _tileSize;


                // 创建当前 Tile 在屏幕上的矩形区域。
                //
                // -1 是为了让每个 Tile 之间留下 1 像素的空隙，
                // 方便我们学习阶段观察网格。
                Rectangle destinationRectangle = new Rectangle(
                    x,
                    y,
                    _tileSize - 1,
                    _tileSize - 1
                );


                // 读取二维数组中当前格子的类型。
                int tileType = _tiles[row, column];


                // 默认设置成绿色。
                //
                // 0 = 草地
                Color tileColor = Color.ForestGreen;


                // == 表示“是否相等”。
                //
                // 如果当前 Tile 类型等于 1，
                // 就代表这个位置是土地。
                if (tileType == 1)
                {
                    tileColor = Color.SaddleBrown;
                }


                // 把当前 Tile 绘制到屏幕。
                spriteBatch.Draw(
                    _tileTexture,
                    destinationRectangle,
                    tileColor
                );
            }
        }
    }
}