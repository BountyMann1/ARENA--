using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behavior : MonoBehaviour
{
    //1
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    //2
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;
    void Start()
    {
        //3
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
    }
    void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * _vInput * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + moveDirection);
        Vector3 rotation = Vector3.up * _hInput * Time.fixedDeltaTime;
        Quaternion angleRot = Quaternion.Euler(rotation);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}