using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnXP;
    public GameObject spawnXM;

    public GameObject spawnYP;
    public GameObject spawnYM;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("PortalXP"))
        {
            player.transform.position = new Vector2 (spawnXP.transform.position.x, player.transform.position.y);
        }
        if (other.CompareTag("PortalXM"))
        {
            player.transform.position = new Vector2(spawnXM.transform.position.x, player.transform.position.y);
        }
            if (other.CompareTag("PortalYP"))
        {
            player.transform.position = new Vector2(player.transform.position.x, spawnYP.transform.position.y);
        }
        if (other.CompareTag("PortalYM"))
        {
            player.transform.position = new Vector2(player.transform.position.x, spawnYM.transform.position.y);
        }
    }// como funciona los teleporst
}
