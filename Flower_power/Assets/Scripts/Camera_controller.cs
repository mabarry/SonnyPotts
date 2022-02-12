using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    [SerializeField] private float speed;
    private float current_pos_x;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float ahead_distance;
    [SerializeField] private float camera_speed;
    private float look_ahead;

    [SerializeField] float topLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float leftLimit;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + look_ahead, player.position.y, transform.position.z);
        look_ahead = Mathf.Lerp(look_ahead, (ahead_distance * player.localScale.x), Time.deltaTime * camera_speed);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z
        );


    }
}
