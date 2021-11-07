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

    public bool estaEnPortal;
    public float tiempoEnElPortal=0.1f;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("PortalXP")&& estaEnPortal==false)
        {
            player.transform.position = new Vector2 (spawnXM.transform.position.x, player.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
        if (other.CompareTag("PortalXM") && estaEnPortal == false)
        {
            player.transform.position = new Vector2(spawnXP.transform.position.x, player.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
            if (other.CompareTag("PortalYP") && estaEnPortal == false)
        {
            player.transform.position = new Vector2(player.transform.position.x, spawnYM.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
        if (other.CompareTag("PortalYM") && estaEnPortal == false)
        {
           // Debug.Log("deberia funcionar");
            player.transform.position = new Vector2(player.transform.position.x, spawnYP.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
    }// como funciona los teleporst
    IEnumerator VolverUsarPortal()
    {
        estaEnPortal = true;
        yield return new  WaitForSeconds(tiempoEnElPortal);
        estaEnPortal = false;

    }
}
