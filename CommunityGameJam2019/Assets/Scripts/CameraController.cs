using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform cameraTarget;

    public float maxDistance;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (new Vector3(mousePos.x, mousePos.y, player.position.z) - player.position).normalized;
        cameraTarget.position = player.position + direction * maxDistance;
    }
}
