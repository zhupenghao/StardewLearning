using System;
namespace MyFarm.Characters;

/// <summary>
/// 玩家状态类，包含金钱、经验、等级、耐力等属性
/// </summary>


public class PlayerStats

{
    /// <summary>
    ///当前拥有的金钱数量
    /// 
    /// public get:
    /// 外部代码可以读取
    /// public set:
    /// 只有 PlayerStats 自己可以修改，
    /// 防止其他系统随意写入非法数值
    /// </summary>
    public int Money { get; set; } // 金钱属性
    public int Stamina { get; set; } // 耐力属性
    public int MaxStamina { get; private set; } // 最大耐力属性

    //2. 构造函数(接收参数)
    public PlayerStats(
     int money,
     int stamina,
     int maxStamina
    )
    { //3. 初始化玩家状态属性，参数赋值
        Money = money;
        Stamina = stamina;
        MaxStamina = maxStamina;


    }
    //3. 方法：花费耐力
    public bool SpendStamina(int amount)
    {
        if (amount <= 0)
        {
            return false; // 无效的花费耐力数值
        }
        if (Stamina > amount)
        {
            Stamina -= amount; // 扣除耐力
            return true; // 花费成功
        }
        return false; // 耐力不足，花费失败
    }
}