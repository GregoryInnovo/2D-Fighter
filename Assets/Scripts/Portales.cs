using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnX;

    public GameObject spawnY;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("PortalX"))
        {
            player.transform.position = new Vector2 (spawnX.transform.position.x, player.transform.position.y);
        }
        if (other.CompareTag("PortalY"))
        {
            player.transform.position = new Vector2(player.transform.position.x, spawnY.transform.position.y);
        }
    }
}
