using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : BaseLevel
{
    public override void InitState(LevelController ctx)
    {
        base.InitState(ctx);
        level = LevelController.LevelSelector.Level_1;       
    }

    public override void SetNextLevel(LevelController.LevelSelector Level_2)
    {
        base.SetNextLevel(Level_2);
    }

    public override void EnterState()
    {
        base.EnterState();
        CameraController.Instance.SetMaxSize(90);
        target.SetPosition();
    }
}
