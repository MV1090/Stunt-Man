using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Aiming : MonoBehaviour
{
    //Start is called before the first frame update
    // [SerializeField] LineRenderer _lr;
    // [SerializeField] float _step;
    // public float _time;
    // float _finalAngle;


    [SerializeField] public float _angle;
    [SerializeField] public float _initialVel;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _movementSpeed;
    [SerializeField] float _minVel;
    [SerializeField] float _maxVel;

    public bool hasFired;
  
    void Start()
    {
        hasFired = false;
    }
        
    void Update()
    {
        if (hasFired == true)
            return;

        setAngle();
        setVelocity();
        MinMaxVelocity();                   
    }   

    public void setAngle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _angle += _movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            _angle -= _movementSpeed * Time.deltaTime;        
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
        if (_initialVel > _maxVel)
            _initialVel = _maxVel;
        if (_initialVel < _minVel)
            _initialVel = _minVel;
    }
   
}
