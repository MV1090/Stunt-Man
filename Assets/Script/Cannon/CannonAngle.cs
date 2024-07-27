using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CannonAngle : MonoBehaviour
{
    [SerializeField] Aiming _projectileAim;

    float _smooth = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(_projectileAim._angle * -1, 90, 0); 

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * _smooth);
    }

}
