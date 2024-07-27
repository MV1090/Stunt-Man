using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
   [SerializeField] float _initialVel;   
   [SerializeField] float _angle;
   [SerializeField] Aiming _projectileAim;
   [SerializeField] Transform _spawnPoint;
    
    private void Start()
    {
        _projectileAim = GameObject.Find("TrajectoryLine").GetComponent<Aiming>();
        _spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();

        _initialVel = _projectileAim._initialVel;
        _angle = _projectileAim._angle;

        float angle = _angle * Mathf.Deg2Rad;

        StopAllCoroutines();
        StartCoroutine(Movement(_initialVel, angle));

        Destroy(gameObject, 5);
    }

    

    IEnumerator Movement(float initialVel, float angle)
    {
        float t = 0;
        while (t < 100)
        {
            float xPos = initialVel * t * Mathf.Cos(angle);
            float yPos = initialVel * t * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(t, 2);
            transform.position = _spawnPoint.position + new Vector3(xPos, yPos, 0);
            
            t += Time.deltaTime;
            yield return null;
        }
    }

    

}
