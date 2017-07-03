using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passa_logo : MonoBehaviour {

    private float tempo;
    public float duracao;
    public string cena;
    public GameObject img1;
    public GameObject img2;

	// Use this for initialization
	void Start () {
        tempo = 0;
        img2.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        tempo  += Time.deltaTime;

        if (tempo >= duracao)
        {
            img1.SetActive(false);
            img2.SetActive(true);
        }
        if (tempo >= duracao + duracao)
        {
            SceneManager.LoadScene("menu");
        }
    }
}
