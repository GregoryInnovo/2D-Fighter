using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    public Animator anim;

    public void SelectScene(int v) {
      
        switch (v) {
            case 0:
               
                StartCoroutine(FadeSalida("Menu"));
                Debug.Log("Escena Menú");         
                break;
            case 1:
                StartCoroutine(FadeSalida("Game"));
                Debug.Log("Escena Game");
            //    SceneManager.LoadScene("FabianScene");
              
                break;
            case 2: 
                Debug.Log("Escena 2");
                StartCoroutine(FadeSalida("Estadisticas"));
            break;
            case 3: 
                Debug.Log("Escena game");

            break;
            default: 
                Debug.Log("Escena 2");
            break;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
    IEnumerator FadeSalida(string nombreScena)
    {    
        anim.SetBool("entrando",false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nombreScena);
    }
}
