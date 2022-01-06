using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    // https://www.youtube.com/watch?v=3uyolYVsiWc  para hacer los corazones
    [Header("Numero de vidas actuales")]
    [Range(0, 3)]
    public int health;
    [Header("Numero de vidas totales")]
    [Range(0, 3)]
   
    public int numOfHearts;
    [Space]
    [Space]

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool invencible = false;

    public int id;
    public Slider slider;

    //contador de muertes por cada jugador
    public int vidaP1, vidaP2;
    private void Awake()
    {
        //Obtengo el numero guardado de muertes
        vidaP1 = PlayerPrefs.GetInt("vidaP1Pref");
        vidaP2 = PlayerPrefs.GetInt("vidaP2Pref");
    }
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
        if (health == 0)
        {
      //      Nmuertes++;
            health--;
            SumarMuerte(id);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "daño" && invencible == false)
        {
            TakeADamage();
        }

        if(collision.gameObject.tag == "Ulti" && invencible == false)
        {
            ActiveUlti();
        }

    }
    public void ActiveUlti()
    {
        Debug.Log(slider.value);
        slider.value = 80f;
        Debug.Log(slider.value);
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
        while (invencible == true)
        {
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.5f);
        }

    }
    //Guardo la nueva variable de  numero de muertes
    public void GuardarInt()
    {
        PlayerPrefs.SetInt("vidaP1Pref", vidaP1);
        PlayerPrefs.SetInt("vidaP2Pref", vidaP2);
    }
    //sumo + 1 a la variable anterior dependiendo del id del jugador
    public void SumarMuerte(int id)
    {
        if (id == 1)
        {
            vidaP1++;
        }
        if (id == 2)
        {
            vidaP2++;
        }
        GuardarInt();
    }

}

