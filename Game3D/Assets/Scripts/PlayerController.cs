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

    // Уровень
    Vector3 lastJump = new Vector3(0, 0, 0);

    // Touch
    Vector2 startPos;
    Vector2 direction;
    bool directionChosen;

    // Функция Start (Unity)
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Функция FixedUpdate (Unity)
    void FixedUpdate()
    {
        float moveHorizontal = TouchCheck();
        MovementLogic(moveHorizontal);
        JumpLogic();
    }

    // Функция проверки Touch
    private float TouchCheck()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos.x = touch.position.x;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction.x = touch.position.x - startPos.x;
                    break;

                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen) { }
        return direction.x;
    }

    // Физика движения персонажа
    private void MovementLogic(float moveHorizontal)
    {
        Vector3 movement = new Vector3(Time.deltaTime * moveHorizontal, 0, Speed * Time.deltaTime * 2);

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
