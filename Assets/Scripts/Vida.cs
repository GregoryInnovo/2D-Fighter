using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    // https://www.youtube.com/watch?v=3uyolYVsiWc  para hacer los corazones
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool invencible = false;
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "daño" && invencible == false)
        {
            TakeADamage();
        }
    }
    public void TakeADamage()
    {
        health--;
        StartCoroutine(Invencible());
        StartCoroutine(Color());
    }
    IEnumerator Invencible()
    {
        invencible = true;       
        yield return new WaitForSeconds(3f);
        invencible = false;       
    }
    IEnumerator Color()
    {
        while (invencible==true)
        {
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.5f);
        }
       
    }
  
}

