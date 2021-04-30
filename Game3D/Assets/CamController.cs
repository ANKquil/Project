using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    // Объекты
    GameObject mainCamera;
    public GameObject player;
    public GameObject gameController;

    // Компоненты
    Transform transformPlayer;
    Transform transformMainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.gameObject;
        transformPlayer = player.GetComponent<Transform>();
        transformMainCamera = mainCamera.GetComponent<Transform>(); 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraTransformPosition();
    }

    //
    void CameraTransformPosition()
    {
        transformMainCamera.position = Vector3.Lerp(
            transformMainCamera.position, new Vector3(transformMainCamera.position.x, transformMainCamera.position.y, transformPlayer.position.z - 13f), 
            1f);
    }
}
