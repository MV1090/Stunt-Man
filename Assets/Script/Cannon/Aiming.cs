using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Aiming : MonoBehaviour
{
    //Start is called before the first frame update
    [SerializeField] LineRenderer _lr;
    [SerializeField] float _step;
    [SerializeField] public float _angle;
    [SerializeField] public float _initialVel;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _movementSpeed;
    

    public float _time;
    float _finalAngle;
    void Start()
    {
      _movementSpeed = 50;
    }
        
    void Update()
    {                 
        setAngle();
        setVelocity();
        MinMaxVelocity();           
        DrawPath(_initialVel, _finalAngle, _step);
    }

    private void DrawPath(float initialVel, float angle, float step)
    {
        step = Mathf.Max(0.01f, step);
        float totalTime = 0.5f;
        
        _lr.positionCount = (int)((int)(totalTime / step) + 2f);
        int count = 0;
        for(float i = 0; i < totalTime; i += step)
        {
            float xPos = initialVel * i * Mathf.Cos(angle);
            float yPos = initialVel * i * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(i, 2);
            _lr.SetPosition(count, _spawnPoint.position + new Vector3(xPos, yPos, 0));
            count++;            
        }

        float xPosFinal = initialVel * totalTime * Mathf.Cos(angle);
        float yPosFinal = initialVel * totalTime * Mathf.Sin(angle) - 0.5f * -Physics.gravity.y * Mathf.Pow(totalTime, 2);
        _lr.SetPosition(count, _spawnPoint.position + new Vector3(xPosFinal, yPosFinal, 0));
    }

    public void setAngle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _angle += _movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            _angle -= _movementSpeed * Time.deltaTime;
        _finalAngle = _angle * Mathf.Deg2Rad;
    }

    public void setVelocity()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            _initialVel += _movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            _initialVel -= _movementSpeed * Time.deltaTime;
    }

    public void MinMaxVelocity()
    {
        if (_initialVel > 50)
            _initialVel = 50;
        if (_initialVel < 10)
            _initialVel = 10;
    }
   
}
