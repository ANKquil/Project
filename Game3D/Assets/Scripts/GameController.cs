using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // �������
    public GameObject player;
    public List<GameObject> listGrounds = new List<GameObject>();

    // ����������
    private Transform playerTransform;
    private PlayerController playerController;

    // ��������� ������
    private bool isJump = false;

    // ����
    public double score = 0;
    float[] levelBoost = {1.0f};

    // �������
    int levelNumber = 0;

    // ������� Start (Unity)
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerTransform = player.GetComponent<Transform>();
    }

    // ������� Update (Unity)
    void Update()
    {
        ScoreUpdate();
        CheckPlayer();
    }

    // ���������� ����� ������ �����
    void ScoreUpdate()
    {
        score += Time.deltaTime * levelBoost[levelNumber] * 2;
    }

    // �������� ��������� ������ � ���� ������ ����
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

    // ������������� ��������
    public static GameObject InstantateObject(GameObject prefab, Vector3 pos)
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.GetComponent<Transform>().position = pos;
        return gameObject;
    }
}
