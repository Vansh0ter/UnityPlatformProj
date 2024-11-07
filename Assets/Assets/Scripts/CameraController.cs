using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 position;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        position = player.position;
        position.z = -10f;
        position.x = player.position.x;
        if (player.position.y < 2f)
            position.y = 0f;
        else
            position.y = player.position.y;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }
}
