using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    private Vector3 movement;
    public  void Start()
    {
        ChangeColor(ColorType.Black);
    }
    public void FixedUpdate()
    {
        Move();
        if (CanMove(_rb.transform.position))
        {
        }
        else
        {
            _rb.velocity = Vector3.zero; 
        }
        if (!IsWallInFront())
        {
            transform.Translate(movement);
        }
    }
    public void Move()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rb.velocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }
    bool IsWallInFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement.normalized, out hit, movement.magnitude))
        {

            if (hit.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }
    
    
}
