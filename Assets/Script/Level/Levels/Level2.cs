using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : BaseLevel
{
    public override void InitState(LevelController ctx)
    {
        base.InitState(ctx);
        level = LevelController.LevelSelector.Level_2;
    }

    public override void SetNextLevel(LevelController.LevelSelector Level_3)
    {
        base.SetNextLevel(Level_3);
    }
    
}
