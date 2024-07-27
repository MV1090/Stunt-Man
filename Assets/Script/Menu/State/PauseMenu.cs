using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MenuController;
using UnityEngine.InputSystem;

public class PauseMenu : BaseMenu 
{
    public override void InitState(MenuController ctx)
    {
        base.InitState(ctx);
        state = MenuController.MenuStates.Pause;
    }
    public override void EnterState()
    {
        base.EnterState();
        Time.timeScale = 0.0f;
    }

    public override void ExitState()
    {
        base.ExitState();
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void JumpToSettings()
    {
        context.SetActiveState(MenuController.MenuStates.Settings);
    }
    public void JumpToMainMenu()
    {
        context.SetActiveState(MenuController.MenuStates.MainMenu);
    }

    public void Pause(InputAction.CallbackContext ctx)
    {
        context.Pause();
    }
}
