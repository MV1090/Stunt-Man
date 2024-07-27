using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : BaseMenu 
{
    // Start is called before the first frame update
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.MainMenu;
    }

    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0.0f;
    }

    public override void ExitState()
    {
        base.ExitState();
       // gameObject.SetActive(false);
        Time.timeScale = 1.0f;        
    }

    public void JumpToSettings()
    {
        context.SetActiveState(MenuController.MenuStates.Settings);
    }

    public void JumpToGameState()
    {
        context.SetActiveState(MenuController.MenuStates.GameState);
    }


}
