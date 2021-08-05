using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Difference between main camera position and player position
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame, after all of the other updates are done
    void LateUpdate()
    {
        // Align the main camera position to match the position of the player, but not its rotation
        transform.position = player.transform.position + offset;
    }
}
