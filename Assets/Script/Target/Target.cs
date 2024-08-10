using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Target : MonoBehaviour
{
    float spawnPosition;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
           
        }
    }
    
    public void SetPosition()
    {
        spawnPosition = Random.Range(50, 250);
        transform.position = new Vector3(spawnPosition, 2.2f, 1);
    }
   

}
