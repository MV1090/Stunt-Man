using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    [SerializeField] float _initialVel;   
    [SerializeField] float _angle;
    [SerializeField] float _time;
    [SerializeField] float _dragValue;

    private float angle;  
    
    Aiming _projectileAim;
    Transform _spawnPoint;

    public enum ProjectileState
    {
        InFlight, Sliding, Stopped, OnTarget
    }

    public ProjectileState _projectileState;

    private void Start()
    {        
        _projectileAim = GameObject.Find("AimController").GetComponent<Aiming>();
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
       
        _initialVel = _projectileAim._initialVel;
        _angle = _projectileAim._angle;

         angle = _angle * Mathf.Deg2Rad;         
          
        _projectileState = ProjectileState.InFlight;                      
    }
   
    private void FixedUpdate()
    {
        if (_projectileState == ProjectileState.OnTarget)
            return;

        _time += Time.deltaTime;

        if (_projectileState == ProjectileState.InFlight)
        {
            FlightMovement(_initialVel, angle, _time);
            SetFlightRotation();
        }

        if (_projectileState == ProjectileState.Stopped)
        {
            if (_projectileAim.hasFired == false)
                return;
            else
                StartCoroutine(LandedDelay());
        }

        if (_projectileState == ProjectileState.Sliding)
        {
            SetSlideRotation();
            SlideMovement(_initialVel, angle, _time);
            SetDrag();
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
            _projectileState = ProjectileState.Stopped;
            //hasStopped = true;
        else
           transform.position = nextPosition;
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
        transform.Rotate(0.5f, 0, 0, Space.Self);
    }
    private void SetAnimationTrigger(string trigger)
    {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger(trigger);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
            return;

        if (collision.gameObject.tag == "Target")
        {
            SetAnimationTrigger("hasLanded");
            SetAnimationTrigger("hitTarget");
            SetSlideRotation();
            _projectileState = ProjectileState.OnTarget;           
        }
        if (collision.gameObject.tag == "Ground")
        { _projectileState = ProjectileState.Sliding;
            SetAnimationTrigger("hasLanded");
            Debug.Log("HasHit");
        }
    }
    private IEnumerator LandedDelay()
    {        
       yield return new WaitForSeconds(2);
       ResetProjectile();
    }
    public void winner()
    {
        MenuController.Instance.SetActiveState(MenuController.MenuStates.WinScreen);
        ResetProjectile();       
    }    
    private void ResetProjectile()
    {
        CameraController.Instance.SetZoomedIn();
       _projectileAim.hasFired = false;
        Destroy(gameObject);
    }
   
}
