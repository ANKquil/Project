using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Объекты
    public GameObject player;
    public List<GameObject> listGrounds = new List<GameObject>();

    // Компоненты
    private Transform playerTransform;
    private PlayerController playerController;

    // Параметры игрока
    private bool isJump = false;

    // Счет
    public double score = 0;
    float[] levelBoost = {1.0f};

    // Уровень
    int levelNumber = 0;

    // Функция Start (Unity)
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Функция Update (Unity)
    void Update()
    {
        ScoreUpdate();
        CheckPlayer();
    }

    // Обновление счета каждый фрейм
    void ScoreUpdate()
    {
        score += Time.deltaTime * levelBoost[levelNumber] * 2;
    }

    // Проверка положения игрока и тест логики игры
    void CheckPlayer()
    {
        if (playerTransform.position.y > 1.6f)
        {
            isJump = true;
        }
        if ((playerTransform.position.y < 1.6f) && (isJump))
        {
            InstantateObject(listGrounds[0], new Vector3(playerTransform.position.x, 0, playerTransform.position.z + 1f));
            isJump = false;
        }
    }

    // Инициализация объектов
    public static GameObject InstantateObject(GameObject prefab, Vector3 pos)
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.GetComponent<Transform>().position = pos;
        return gameObject;
    }
}
