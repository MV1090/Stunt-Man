using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{

    [SerializeField] Projectile _stuntMan;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Aiming angleOfFire;

    private void Start()
    {
        
    }
    void Update()
    {
        Quaternion target = Quaternion.Euler(angleOfFire._angle * -1, 90 ,0);
        //Vector3 launchPosition = new Vector3(_spawnPoint.position.x + 1.25f, _spawnPoint.position.y - 3.055306f, _spawnPoint.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_stuntMan, _spawnPoint.position, target);
        }
    }
}
