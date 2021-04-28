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

    // ������� Start (Unity)
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // ������� FixedUpdate (Unity)
    void FixedUpdate()
    {
        MovementLogic();
    }

    // ������ �������� ���������
    private void MovementLogic()
    {
        Vector3 movement = new Vector3(Time.deltaTime * 2, 0.0f, 0 /* Speed * Time.deltaTime * 2*/);

        _rb.AddForce(movement);
    }
}
