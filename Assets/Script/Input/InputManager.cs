using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
 
    PlayerInput input;
    public PauseMenu context;
    public void Awake()
    {
      input = new PlayerInput();
    }

    private void OnEnable()
    {
       input.Enable();
       input.Pause.Pause.performed += context.Pause;
       
    }

    private void OnDisable()
    {
       input.Disable();

    }
}

