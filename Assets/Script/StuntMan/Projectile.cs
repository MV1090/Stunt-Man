using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    [SerializeField] float _initialVel;   
    [SerializeField] float _angle;
    [SerializeField] float _time;
    [SerializeField] float _dragValue;

    private float angle;
    private bool isFlying;   
    public bool hasStopped;  

    private Camera _cam;
    Aiming _projectileAim;
    Transform _spawnPoint;

    private void Start()
    {        
        _projectileAim = GameObject.Find("TrajectoryLine").GetComponent<Aiming>();
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        _cam = GetComponentInChildren<Camera>();

        _cam.enabled = true;

        _initialVel = _projectileAim._initialVel;
        _angle = _projectileAim._angle;

         angle = _angle * Mathf.Deg2Rad;             

        Destroy(gameObject, 30);

        isFlying = true;
        hasStopped = false;    
        
    }
    void Update()
    {               
        if (isFlying == false)
            return;
        SetFlightRotation();
    }

    private void FixedUpdate()
    {
        if (hasStopped == true)
            _cam.enabled = false;
        else
        {
            _time += Time.deltaTime;

            if (isFlying == true)
            {
                FlightMovement(_initialVel, angle, _time);
            }
            else
            {
                SetSlideRotation();
                SlideMovement(_initialVel, angle, _time);
                SetDrag();
            }
        }
    }           
    private void FlightMovement(float initialVel, float angle, float time)
    {             
        float xPos = initialVel * time * Mathf.Cos(angle);
        float yPos = initialVel * time * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(time, 2);
        transform.position = _spawnPoint.position + new Vector3(xPos, yPos, 0);
    }

    private void SlideMovement(float initialVel, float angle, float time)
    {
        float xPos = initialVel * time * Mathf.Cos(angle);               
        Vector3 nextPosition = _spawnPoint.position + new Vector3(xPos, -1.2f, 0);
        
        if (nextPosition.x < transform.position.x)
            hasStopped = true;
        
        transform.position = nextPosition;
    }

    private void SetAnimationTrigger(string trigger)
    {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger(trigger);
    }

    private void SetDrag()
    {
        _initialVel -= Time.deltaTime * _dragValue;
        _dragValue += Time.deltaTime;        
    }

    private void SetSlideRotation()
    {
        transform.rotation = Quaternion.Euler(_spawnPoint.rotation.x - 0.2f, _spawnPoint.rotation.y + 90, _spawnPoint.rotation.z - angle);
    }

    private void SetFlightRotation()
    {
        transform.Rotate(0.2f, 0, 0, Space.Self);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
            return;

        SetAnimationTrigger("hasLanded");
        Debug.Log("HasHit");
        isFlying = false;        
    } 
}
