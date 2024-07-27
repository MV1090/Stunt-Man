using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    [SerializeField] Aiming _projectilePower;
    
    Slider _powerBar;
    // Start is called before the first frame update
    void Start()
    {
        _powerBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _powerBar.value = _projectilePower._initialVel;
    }
}
