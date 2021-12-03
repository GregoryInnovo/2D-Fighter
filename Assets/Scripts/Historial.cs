using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historial : MonoBehaviour
{
    public static Historial instance;
    public GameObject player1, player2;
    public Text vidaP1Text, vidaP2Text;
    private void Awake()
    {
        VidaPlayersGui();
        EncontrarVar();
    }
    public void EncontrarVar()
    {
        player1.GetComponent<Vida>().vidaP1 = PlayerPrefs.GetInt("vidaP1Pref");
        player2.GetComponent<Vida>().vidaP2 = PlayerPrefs.GetInt("vidaP2Pref");

        vidaP1Text.text = "Muertes totales: " + player1.GetComponent<Vida>().vidaP1;
        vidaP2Text.text = "Muertes totales: " + player2.GetComponent<Vida>().vidaP2;
    }
   
   
    public void VidaPlayersGui()
    {
        //vidaP1Text.text ="Muertes totales: "+ vidaP1.ToString();
        //vidaP2Text.text = "Muertes totales: "+ vidaP2.ToString();
    }
    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
