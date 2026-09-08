using MyFarm.Characters;

namespace MyFarm.Core;

partial class GameState
{
    public Player Player { get;  } // 玩家对象属性

    public GameState()
    {
        var playstats = new PlayerStats(
            money: 500,
            stamina: 100,
            maxStamina: 120
        ); // 初始化玩家状态
        Player = new Player(name: "云生", stats: playstats); // 初始化玩家对象
    }

}
