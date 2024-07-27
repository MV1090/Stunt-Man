using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseMenu
{
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.GameState;
    }

}
