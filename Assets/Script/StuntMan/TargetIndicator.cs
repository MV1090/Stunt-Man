using UnityEngine;


public class TargetIndicator : MonoBehaviour
{
    [SerializeField] Transform target;

    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
