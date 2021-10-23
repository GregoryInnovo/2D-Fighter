using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    //public float fuerzaSalto;
    public bool estaEnSuelo=false;
    public Vector2 fuerzaY;
    public Vector2 fuerzaX;
    public Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fuerzaY = new Vector2(0f, 3f);
        fuerzaX = new Vector2(2f, 0f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && estaEnSuelo==true)
        {
            //      this.gameObject.transform.position = transform.position + new Vector3(0f,this.gameObject.transform.position.y + fuerzaSalto, 0f);
            rb.AddForce(fuerzaY, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(fuerzaX, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(-fuerzaX, ForceMode2D.Impulse);
        }

    }
    private void FixedUpdate()
    {
    
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            estaEnSuelo = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        estaEnSuelo = false;
    }

}
