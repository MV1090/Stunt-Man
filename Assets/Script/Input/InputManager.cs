using UnityEngine;

public class InputManager : MonoBehaviour
{
 
    PlayerInput input;
    public PauseMenu context;
    public Shoot cannon;
    public CameraController cameraZoom;
    public void Awake()
    {
      input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();       
        input.Shoot.Fire.performed += cannon.Fire;
        input.Camera.Zoom.performed += cameraZoom.ToggleCameraZoom;        
    }

    private void OnDisable()
    {
       input.Disable();
       input.Camera.Zoom.performed -= cameraZoom.ToggleCameraZoom;
       input.Shoot.Fire.performed -= cannon.Fire;
    }
}

