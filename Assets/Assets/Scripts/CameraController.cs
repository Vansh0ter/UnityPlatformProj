using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 position;

    private void Update()
    {
        position = player.position;
        position.z = -10f;
        position.x = player.position.x;
        if (player.position.y < 1.2f)
            position.y = 0f;
        else
            position.y = player.position.y;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
