using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    public MenuController.MenuStates state;
    protected MenuController context;

    public virtual void InitState(MenuController ctx)
    {
        context = ctx;
    }

    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }
    public void JumpBack()
    {
        context.JumpBack();
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
