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
            
        }
        if (Input.GetKey(derecha))
      
        {
            //       rb.AddForce(-fuerzaX, ForceMode2D.Impulse);
            rb.velocity = new Vector2(velMove, rb.velocity.y);
            playerSprite.flipX = false;
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

}
