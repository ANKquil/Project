using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // �������
    public GameController gamecontroller;

    // ����������
    Rigidbody _rb;

    // ��������� ������
    float Speed = 50f;
    float JumpForce = 200f;
    public bool _isGrounded;

    // ������� Start (Unity)
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // ������� FixedUpdate (Unity)
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    // ������ �������� ���������
    private void MovementLogic()
    {
        Vector3 movement = new Vector3(Time.deltaTime * Speed / 10, 0.0f, Speed * Time.deltaTime * 2);

        _rb.AddForce(movement);
    }

    // ������ ������
    private void JumpLogic()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * JumpForce + Vector3.forward * JumpForce * 0.75f);
        }
    }

    // ������� �������� �� ������� �������� (Unity)
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    // ������� �������� �� ���������� �������� (Unity)
    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    // ������� ������������� ��������
    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
