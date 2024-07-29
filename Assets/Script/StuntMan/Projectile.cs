using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
   [SerializeField] float _initialVel;   
   [SerializeField] float _angle;
    [SerializeField] float _time;
    [SerializeField] Aiming _projectileAim;
   [SerializeField] Transform _spawnPoint;

    private float angle;
    private bool isFlying;
    private void Start()
    {
        _projectileAim = GameObject.Find("TrajectoryLine").GetComponent<Aiming>();
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();

        _initialVel = _projectileAim._initialVel;
        _angle = _projectileAim._angle;

         angle = _angle * Mathf.Deg2Rad;
             

        Destroy(gameObject, 5);

        isFlying = true;
    }

    private void FixedUpdate()
    {
       _time += Time.deltaTime;
        //FlightMovement(_initialVel, angle, _time);
        if (isFlying == true)
            FlightMovement(_initialVel, angle, _time);

        else
            SlideMovement(_initialVel, angle, _time);
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
        transform.position = _spawnPoint.position + new Vector3(xPos, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
            return;

        Debug.Log("HasHit");
        isFlying = false;
    }

 



}
