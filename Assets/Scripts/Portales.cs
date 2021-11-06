using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    public GameObject player;
    public GameObject spwan;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Pared"))
        {

            player.transform.position = new Vector2 (spwan.transform.position.x, player.transform.position.y);
        }
    }
}
