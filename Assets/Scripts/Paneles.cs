using UnityEngine;
using UnityEngine.UI;

public class Paneles : MonoBehaviour
{
    public Vida vidaplayer1;
    public Vida vidaplayer2;

    public GameObject panelGameOver;
    public Text textGameOver;
    public Text text_Timer;
    public float timer;

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
        text_Timer.text = timer.ToString("0");
        if (timer >= 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else
            Destroy(text_Timer);
    }

}
