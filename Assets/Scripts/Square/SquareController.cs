using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareController : MonoBehaviour
{
    [SerializeField] private float _rotationPower;
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rotationPower *= GetRandomSign();
    }

    private void FixedUpdate()
    {
        _rigidBody.rotation += _rotationPower;
        _rigidBody.velocity = _direction * _speed;
    }

    private int GetRandomSign()
    {
        var randomNumber = Random.Range(0, 2);
        return randomNumber == 1 ? 1 : -1;
    }
}
