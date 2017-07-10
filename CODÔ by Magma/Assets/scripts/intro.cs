using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

    public string nomeCenaJogo;
    public GameObject fundoMusical;

    void Awake (){
        DontDestroyOnLoad(fundoMusical.gameObject);
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown == true) {
            SceneManager.LoadScene(nomeCenaJogo);
        }   
	}
}
