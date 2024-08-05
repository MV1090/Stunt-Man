using UnityEngine;
using UnityEngine.InputSystem;



public class Shoot : MonoBehaviour
{

    [SerializeField] Projectile _stuntMan;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Aiming angleOfFire;
    Quaternion target;
    private void Start()
    {
        
    }
    void Update()
    {
        target = Quaternion.Euler(angleOfFire._angle * -1, 90 ,0);              
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        CameraController.Instance.setFollowCam();
        Instantiate(_stuntMan, _spawnPoint.position, target);        
    }

}
