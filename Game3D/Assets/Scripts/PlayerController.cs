using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Объекты
    public GameController gamecontroller;

    // Компоненты
    Rigidbody _rb;

    // Параметры игрока
    float Speed = 50f;
    float JumpForce = 200f;
    public bool _isGrounded;

    // Функция Start (Unity)
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Функция FixedUpdate (Unity)
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    // Физика движения персонажа
    private void MovementLogic()
    {
        Vector3 movement = new Vector3(Time.deltaTime * 2, 0.0f, 0 /* Speed * Time.deltaTime * 2*/);

        _rb.AddForce(movement);
    }

    // Физика прыжка
    private void JumpLogic()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * JumpForce + Vector3.forward * JumpForce * 0.75f);
        }
    }
}
