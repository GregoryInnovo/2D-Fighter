using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public TrailRenderer tr;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private TrailRenderer myTrail;
    public KeyCode keyDashLeft, keyDashRight, keyDashUp, keyDash;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        myTrail = GetComponent<TrailRenderer>();
        myTrail.enabled = !myTrail.enabled;
    }
    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKey(keyDashLeft) && Input.GetKey(keyDash))
            {
                direction = 1;
                StartCoroutine(efecto());
                Debug.Log("deberia funcionar una vez");
            }
            else if
                (Input.GetKey(keyDashRight) && Input.GetKey(keyDash))
            {
                direction = 2;

            }
            else if (Input.GetKey(keyDashUp) && Input.GetKey(keyDash))
            {
                direction = 3;

            } 
              
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
             
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    //  tr activar y desactivar el trailrenderer cuando se hace el dash
                
                }
                if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    
                }
                if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                 
                }

            }
        }
    }
    IEnumerator efecto()
    {
        myTrail.enabled = myTrail.enabled;
        yield return new WaitForSeconds(2f);
        myTrail.enabled = !myTrail.enabled;
    }
}
