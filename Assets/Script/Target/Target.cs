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
        spawnPosition = Random.Range(30, 250);
        transform.position = new Vector3(spawnPosition, 4.5f, 0);
    }
   

}
