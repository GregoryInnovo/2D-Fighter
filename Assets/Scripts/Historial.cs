using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historial : MonoBehaviour
{
    public static Historial instance;
    public int vidaP1, vidaP2;
    public Text vidaP1Text, vidaP2Text;
    public void Awake()
    {
     
        vidaP1 = PlayerPrefs.GetInt("vidaP1Pref");
        vidaP2 = PlayerPrefs.GetInt("vidaP2Pref");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        VidaPlayersGui();
        DontDestroyOnLoad(gameObject);
    }
    public void GuardarInt()
    {
        PlayerPrefs.SetInt("vidaP1Pref", vidaP1);
        PlayerPrefs.SetInt("vidaP2Pref", vidaP2);
    }
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
        VidaPlayersGui();
    }
    public void VidaPlayersGui()
    {
        vidaP1Text.text ="Muertes totales: "+ vidaP1.ToString();
        vidaP2Text.text = "Muertes totales: "+ vidaP2.ToString();
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
