using UnityEngine;
using UnityEngine.InputSystem;



public class Shoot : MonoBehaviour
{

    [SerializeField] Projectile _stuntMan;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Aiming angleOfFire;
    [SerializeField] ParticleSystem smoke;
    Quaternion target;
    
    void Update()
    {
        target = Quaternion.Euler(angleOfFire._angle * -1, 90 ,0);              
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        if (angleOfFire.hasFired)
            return;
       
        smoke.Play();
        angleOfFire.hasFired = true;
        CameraController.Instance.setFollowCam();
        Instantiate(_stuntMan, _spawnPoint.position, target);        
    }

}
