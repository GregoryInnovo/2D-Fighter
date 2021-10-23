using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    //public float fuerzaSalto;
    public bool estaEnSuelo=false;
    public Vector2 fuerzaY;
    public Rigidbody2D rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fuerzaY = new Vector2(0f, 2f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && estaEnSuelo==true)
        {
            //      this.gameObject.transform.position = transform.position + new Vector3(0f,this.gameObject.transform.position.y + fuerzaSalto, 0f);
            rb.AddForce(fuerzaY, ForceMode2D.Impulse);
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
