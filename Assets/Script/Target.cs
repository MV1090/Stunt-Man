using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private BaseLevel[] targetLevel;
    private int nextLevel;
    private int currentLevel;

    private void Start()
    {
     nextLevel = 1;
     currentLevel = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            //targetLevel[currentLevel].SetNextLevel();
        }
    }
    
   

}
