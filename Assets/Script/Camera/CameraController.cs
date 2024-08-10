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
        
    private float smoothTime;

    Vector3 velocity = Vector3.zero;

    private float minOrthographicSize;
    private float maxOrthographicSize;
    public GameObject stuntman;

    private float xOffset;
    private float yOffset;

    [Range(0.0f, 1.0f)]
    public float cameraSpeed;
       
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {       
        _cameraState = CameraState.ZoomedIn;
        minOrthographicSize = 10;

        xOffset = 14.35f;
        yOffset = 6.92f;

    }

    // Update is called once per frame
    void Update()
    {
        if (_cameraState == CameraState.FollowState)
        {
            if (stuntman == null)
            {
                ResetOffSet();
                stuntman = GameObject.Find("StuntMan(Clone)");                
            }
            else
            {
                transform.position = new Vector3(stuntman.transform.position.x + xOffset, stuntman.transform.position.y + yOffset, stuntman.transform.position.z - 10);
                XOffSet();
                YOffSet();
                smoothTime += cameraSpeed;
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

    public void SetZoomedIn()
    {
        _cameraState = CameraState.ZoomedIn;
    }

    private void XOffSet()
    {
        if (xOffset > 0f)
            xOffset -= Time.deltaTime * smoothTime;

        if (xOffset < 0f)
            xOffset = 0f;
    }

    private void YOffSet()
    {
        if(yOffset > 5)
            yOffset -= Time.deltaTime * smoothTime;

        if(yOffset < 5)
            yOffset = 5;
    }

    private void ResetOffSet()
    {
        xOffset = 14.35f;
        yOffset = 6.92f;
        smoothTime = 1f;
    }


}
