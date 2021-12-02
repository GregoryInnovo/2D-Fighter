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

    private GameObject player1, player2;
    private bool auxActivePlayers;

    private void Start()
    {
        panelGameOver.SetActive(false);

        // Encuentra el gameObject
        player1 = GameObject.Find("Player_1");
        player2 = GameObject.Find("Player_2");   
        auxActivePlayers = true;    
    }
    
    private void Update()
    { 
        // timer inicio
        if (vidaplayer1.health <= 0)
        {
            panelGameOver.SetActive(true);
            textGameOver.text = "Player 1 ha perdido";
            // Desactivar players
            ToggleDisablePlayer();
        }
        if(vidaplayer2.health <= 0)
        {
            panelGameOver.SetActive(true);
            textGameOver.text = "Player 2 ha perdido";
            // Desactivar players
            ToggleDisablePlayer();
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
        if(auxActivePlayers) {
            // Activar players
            ToggleDisablePlayer();
            auxActivePlayers= false;
        }
    }

    void ToggleDisablePlayer() {
        player1.GetComponent<Salto>().enabled = !player1.GetComponent<Salto>().enabled;
        player2.GetComponent<Salto>().enabled = !player2.GetComponent<Salto>().enabled;
    }

}
