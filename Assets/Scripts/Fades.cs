using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    public Animator anim;
    void Awake()
    {
      
        // The GameObject cannot jump 
        DontDestroyOnLoad(this.gameObject);
    }

    public void FadeEntrando()
    {
        anim.SetBool("entrando", true);
    }
    public void FadeSaliendo()
    {
        anim.SetBool("entrando", false);
    }
}
