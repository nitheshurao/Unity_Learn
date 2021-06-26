using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x + 1, player.position.y, -10); // Camera follows the player but 6 to the right
    }
}
