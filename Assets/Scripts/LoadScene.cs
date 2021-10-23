using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void SelectScene(int v) {
        switch(v) {
            case 0: 
                Debug.Log("Escena Menú");
                SceneManager.LoadScene("Menu");
            break;
            case 1: 
                Debug.Log("Escena 1");
                SceneManager.LoadScene("FabianScene");
            break;
            case 2: 
                Debug.Log("Escena 2");
                // SceneManager.LoadScene(2);
            break;
            case 3: 
                Debug.Log("Escena 2");
            break;
            default: 
                Debug.Log("Escena 2");
            break;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
