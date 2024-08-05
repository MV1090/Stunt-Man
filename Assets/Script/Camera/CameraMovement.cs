using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{    
      
    [SerializeField] float minXClamp;
    [SerializeField] float maxXClamp;
    [SerializeField] float minYClamp;
    [SerializeField] float maxYClamp;

    [Range(0.0f, 1.0f)]
    public float smoothTime;

    Vector3 velocity = Vector3.zero;

    Transform parent;

    private void Start()
    {
        parent = GetComponentInParent<Transform>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(parent.transform.rotation.x - parent.transform.rotation.x, 0, 0);
        Vector3 cameraPosition = transform.position;
        
        cameraPosition.x = Mathf.Clamp(transform.position.x, minXClamp, maxXClamp);
        cameraPosition.y = Mathf.Clamp(transform.position.y, minYClamp, maxYClamp);


        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothTime);
    }
}
