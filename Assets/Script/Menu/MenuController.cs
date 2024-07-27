using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class MenuController : MonoBehaviour
{
    public BaseMenu[] allMenus; 
    public enum MenuStates
    {
        MainMenu, Settings, Pause, GameState
    }

    private BaseMenu currentState;
    public Dictionary<MenuStates, BaseMenu> menuDictionary = new Dictionary<MenuStates, BaseMenu>();
    private Stack<MenuStates> menuStack = new Stack<MenuStates>();

    // Start is called before the first frame update
    void Start()
    {
        if (allMenus == null) return;

        foreach (BaseMenu menu in allMenus)
        {
            if(menu == null) continue;

            menu.InitState(this);

            if (menuDictionary.ContainsKey(menu.state))
                continue;

            menuDictionary.Add(menu.state, menu);

        }

        foreach (MenuStates state in menuDictionary.Keys)
        {
            menuDictionary[state].gameObject.SetActive(false);
        }
        SetActiveState(MenuStates.MainMenu);
    }

    public void SetActiveState(MenuStates newState, bool isJumpingBack = false)
    {
        if (!menuDictionary.ContainsKey(newState))
            return;

        if (currentState !=null) 
        {
            currentState.ExitState();
            currentState.gameObject.SetActive(false);
        }

        currentState = menuDictionary[newState];
        currentState.gameObject.SetActive(true);    
        currentState.EnterState();

        if(!isJumpingBack)
        {
            menuStack.Push(newState);
        }

    }
    public void JumpBack()
    {
        if(menuStack.Count >= 1)
        {
            SetActiveState(MenuStates.MainMenu);
        }
        else
        {
            menuStack.Pop();
            SetActiveState(menuStack.Peek(), true);
        }
    }

    public void Pause()
    {
        if (currentState == menuDictionary[MenuStates.GameState])
            SetActiveState(MenuStates.Pause);

        else if(currentState == menuDictionary[MenuStates.Pause])
        {
            SetActiveState(MenuStates.GameState);
        }            
    }
}
