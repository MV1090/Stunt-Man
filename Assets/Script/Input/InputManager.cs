using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
 
    PlayerInput input;
    public PauseMenu context;
    public Shoot cannon;
    public void Awake()
    {
      input = new PlayerInput();
    }

    private void OnEnable()
    {
       input.Enable();
       input.Pause.Pause.performed += context.Pause;
        input.Shoot.Fire.performed += cannon.Fire;
    }

    private void OnDisable()
    {
       input.Disable();

    }
}

