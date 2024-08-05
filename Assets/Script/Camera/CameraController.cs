using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraController : Singleton<CameraController>
{
    private enum CameraState
    { ZoomedIn, ZoomedOut, FollowState }

    private CameraState _cameraState;

    [SerializeField] Camera cameraRef;   
    [SerializeField] float minXClamp;
    [SerializeField] float maxXClamp;
    [SerializeField] float minYClamp;
    [SerializeField] float maxYClamp;

    [Range(0.0f, 1.0f)]
    public float smoothTime;

    Vector3 velocity = Vector3.zero;

    private float minOrthographicSize;
    private float maxOrthographicSize;
    public GameObject stuntman;  
       
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {       
        _cameraState = CameraState.ZoomedIn;
        minOrthographicSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (_cameraState == CameraState.FollowState)
        {
            if (stuntman == null)
            {
                stuntman = GameObject.Find("Falling(Clone)");
                if (stuntman != null)
                {
                    if (stuntman.GetComponent<Projectile>().hasStopped == true)
                    {
                        cameraRef.enabled = true;
                    }
                    else
                    {
                        cameraRef.enabled = false;
                        Debug.Log("follow state set");
                    }
                }
            }
        }
        
        if (_cameraState == CameraState.ZoomedIn)
        {
           ZoomedIn();
        }

        if (_cameraState == CameraState.ZoomedOut)
        {
            ZoomedOut();
        }
    }

    public void ToggleCameraZoom(InputAction.CallbackContext ctx)
    {
        if (_cameraState == CameraState.FollowState) return;

        if (_cameraState == CameraState.ZoomedIn)
            _cameraState = CameraState.ZoomedOut;

        else
            _cameraState = CameraState.ZoomedIn;
    }

    public void SetMaxSize(float cameraSize)
    {
        maxOrthographicSize = cameraSize;
    }

    private void ZoomedIn()
    {
        cameraRef.orthographicSize = minOrthographicSize;

        cameraPosition.x = cameraRef.orthographicSize * 1.78f;
        cameraPosition.y = cameraRef.orthographicSize;
        cameraRef.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
    }

    private void ZoomedOut()
    {
        cameraRef.orthographicSize = maxOrthographicSize;

        cameraPosition.x = cameraRef.orthographicSize * 1.78f;
        cameraPosition.y = cameraRef.orthographicSize;
        cameraRef.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
    }
    public void setFollowCam()
    {
        if(_cameraState == CameraState.ZoomedOut)
        ZoomedIn();

        _cameraState = CameraState.FollowState;
    }



}
