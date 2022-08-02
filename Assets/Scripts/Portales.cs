using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    public GameObject player;
    [Header("Portales de entrada")]
    //derecha
    public GameObject portalDer;
    public GameObject portalIzq;
    public GameObject portalArriba;
    public GameObject portalAbajo;
    [Header("Portales de salida")]
    public GameObject Der;
    public GameObject izq;
    public GameObject arriba;
    public GameObject abajo;

    public bool estaEnPortal;
    public float tiempoEnElPortal = 0.05f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PortalXP") && estaEnPortal == false)
        {
            player.transform.position = new Vector2(izq.transform.position.x, player.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
        if (other.CompareTag("PortalXM") && estaEnPortal == false)
        {
            player.transform.position = new Vector2(Der.transform.position.x, player.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
        if (other.CompareTag("PortalYP") && estaEnPortal == false)
        {
            player.transform.position = new Vector2(player.transform.position.x, abajo.transform.position.y);
            StartCoroutine(VolverUsarPortal());
        }
        if (other.CompareTag("PortalYM") && estaEnPortal == false)
        {
            // Debug.Log("deberia funcionar");
            player.transform.position = new Vector2(player.transform.position.x, arriba.transform.position.y);
          //  StartCoroutine(VolverUsarPortal());
        }
    }// como funciona los teleporst
    IEnumerator VolverUsarPortal()
    {
        estaEnPortal = true;
        yield return new WaitForSeconds(tiempoEnElPortal);
        estaEnPortal = false;

    }
}
