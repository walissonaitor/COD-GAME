using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoCaminho : MonoBehaviour {

    public bool errou;

    void Awake ()
    {
        PlayerPrefs.SetInt("errou", 0);
    }

    void Update ()
    {
        if (errou == true) {
            PlayerPrefs.SetInt("errou", 1);
        }else
        {
            PlayerPrefs.SetInt("errou", 0);
        }
    }

    public void ResetaErrou()
    {
        errou = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ColisaoDesafio")
        {
            errou = true;
        }
    }
}
