using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float balaSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  rb.velocity = Vector2.right * balaSpeed;
        //rb.velocity = new Vector2(-balaSpeed * Time.fixedDeltaTime, 0f);
    }

    private void OnEnable()
    {
        if (rb != null)
        {
          //   rb.velocity = Vector2.right * balaSpeed;
          //  rb.velocity = new Vector2(-balaSpeed * Time.fixedDeltaTime, 0f);
        }
        Invoke("Disable", 2f);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
