using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Paneles : MonoBehaviour
{
    [SerializeField] Vida vidaplayer1;
    [SerializeField] Vida vidaplayer2;

    [SerializeField] GameObject panelGameOver;
    [SerializeField] Text textGameOver;
    [SerializeField] Text text_Timer;
    [SerializeField] float timer;

    private void Start()
    {
        panelGameOver.SetActive(false);

    }
    private void Update()
    { // timer inicio
        
        if (vidaplayer1.health <= 0)
        {
            panelGameOver.SetActive(true);
            textGameOver.text = "Player 1 ha perdido";
        }
        if(vidaplayer2.health <= 0)
        {
            panelGameOver.SetActive(true);
            textGameOver.text = "Player 2 ha perdido";
        }
        Timer();
    }
    public void Timer()
    {

        if (timer >= 0)
        {
            text_Timer.text = timer.ToString("0");
            timer -= 1 * Time.deltaTime;
        }
        else
        {

            text_Timer.text = ("¡A Jugar!");
            StartCoroutine(espera());
        }
       
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1f);
        Destroy(text_Timer);
    }

}
