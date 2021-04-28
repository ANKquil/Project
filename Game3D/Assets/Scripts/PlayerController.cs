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

    // Функция Start (Unity)
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Функция FixedUpdate (Unity)
    void FixedUpdate()
    {
        MovementLogic();
    }

    // Физика движения персонажа
    private void MovementLogic()
    {
        Vector3 movement = new Vector3(Time.deltaTime * 2, 0.0f, 0 /* Speed * Time.deltaTime * 2*/);

        _rb.AddForce(movement);
    }
}
