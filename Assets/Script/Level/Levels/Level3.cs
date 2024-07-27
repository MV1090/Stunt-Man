using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : BaseLevel
{
    public override void InitState(LevelController ctx)
    {
        base.InitState(ctx);
        level = LevelController.LevelSelector.Level_3;
    }
       
}
