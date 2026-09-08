namespace MyFarm.Characters;

public class Player
{
  public string Name { get; } // 玩家名称属性

  public PlayerStats Stats { get; } // 玩家状态属性

  public Player(string name, PlayerStats stats)
  {
    Name = name;
    Stats = stats;
  }
}