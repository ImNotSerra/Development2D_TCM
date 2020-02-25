using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Transform StartPoint;
    public Transform EndPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.position = GetPosition();
    }

    private Vector2 GetPosition()
    {
        var pos = Vector3.Lerp(StartPoint.position, EndPoint.position, GetFraction());
        return new Vector2(pos.x, pos.y);
    }

    private float GetFraction()
    {

    }
}
