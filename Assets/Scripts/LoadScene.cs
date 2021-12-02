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
                StartCoroutine(FadeSalida("FabianScene"));
                Debug.Log("Escena 1");
            //    SceneManager.LoadScene("FabianScene");
              
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
    IEnumerator FadeSalida(string nombreScena)
    {    
        anim.SetBool("entrando",false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nombreScena);
    }
}
