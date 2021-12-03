using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{//https://www.youtube.com/watch?v=uqofxjeY5fg
    //public float fuerzaSalto;
    public bool estaEnSuelo=false;
    public Vector2 fuerzaY;
    public Vector2 fuerzaX;
    public Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    public float velMove;
    public float velJump;
    public KeyCode izquierda;
    public KeyCode derecha;
    public KeyCode salto;
    public KeyCode abajo;
    public KeyCode disparo;
    public GameObject proyectil;
    public Transform verticeDisparo;
    public Transform verticeDisparoIz;
    public Transform posicionDisparo;
    public int balaSpeed;
    public bool puedeDisparar=true;
    public float tiempoEsperaBala;
    private void Start()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        fuerzaY = new Vector2(0f, 3f);
        fuerzaX = new Vector2(2f, 0f);
    }
    void Update()
    {
        if (Input.GetKeyDown(salto) && estaEnSuelo==true)
        {
            //      this.gameObject.transform.position = transform.position + new Vector3(0f,this.gameObject.transform.position.y + fuerzaSalto, 0f);
            //    rb.AddForce(fuerzaY, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, velJump);
        }
        if(Input.GetKey(izquierda))
        {
           // rb.AddForce(fuerzaX, ForceMode2D.Impulse);
            rb.velocity = new Vector2(-velMove, rb.velocity.y);
            playerSprite.flipX = true;

            posicionDisparo.position = verticeDisparoIz.position;
        }
        if (Input.GetKey(derecha))
      
        {
            //       rb.AddForce(-fuerzaX, ForceMode2D.Impulse);
            rb.velocity = new Vector2(velMove, rb.velocity.y);
            playerSprite.flipX = false;
            posicionDisparo.position = verticeDisparo.position;

        }
        if (Input.GetKey(disparo))
        {
            Fire();
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "suelo")
            estaEnSuelo = true;
        if (collision.gameObject.tag == "Player")
            estaEnSuelo = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        estaEnSuelo = false;
    }
    private void Fire()
    {
        if (puedeDisparar == true)
        {
            int direction()
            {
                if (playerSprite.flipX == true)
                {
                    return -1;
                }
                else
                {
                    return +1;
                }

            }
            //  Instantiate(proyectil, verticeDisparo.position, verticeDisparo.rotation);
            GameObject obj = ObjectPolling.current.GetPooledObject();
            if (obj == null) return;

            obj.transform.position = posicionDisparo.position;
            obj.transform.rotation = posicionDisparo.rotation;
            obj.SetActive(true);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(balaSpeed * direction() * Time.fixedDeltaTime, 0f);
            StartCoroutine(Esperabala());
        }
    }
    IEnumerator Esperabala()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(tiempoEsperaBala);
        puedeDisparar = true;
    }

}
