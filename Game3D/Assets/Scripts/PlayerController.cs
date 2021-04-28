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
        Vector3 movement = new Vector3(Time.deltaTime * Speed / 10, 0.0f, Speed * Time.deltaTime * 2);

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

    // Функция проверки на слияние коллизий (Unity)
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    // Функция проверки на разделение коллизий (Unity)
    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    // Функция использования коллизий
    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
