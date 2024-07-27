using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRotation : MonoBehaviour
{
   
    
    void Update()
    {       
        transform.Rotate(0.2f, 0, 0, Space.Self);  
    }


}


