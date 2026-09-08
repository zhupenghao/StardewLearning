using System;
using System.Text;



class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // 设置控制台输出编码为 UTF-8
        Console.InputEncoding = Encoding.UTF8; // 设置控制台输入编码为 UTF-8
        using var game = new MyFarm.Game1();
        game.Run();
    }
}