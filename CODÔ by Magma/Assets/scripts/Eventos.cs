using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour {

    public bool evento = false;
    public int idEvento;
    public UIGamePlay uIGamePlay;
    public GameObject falasEntrou;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        uIGamePlay = FindObjectOfType(typeof(UIGamePlay)) as UIGamePlay;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        falasEntrou.SetActive(false);
    }

    float tempo = 0;
    float duracao = 3;
    // Update is called once per frame
    void Update()
    {
        if (evento == true) {
            tempo += Time.deltaTime;
                if (gameController.CurrentState == StateMachine.INGAME)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        uIGamePlay.EntrarQuest(idEvento - 1);
                        PlayerPrefs.SetInt("ULTIMAFASE", idEvento);
                        PlayerPrefs.SetInt("USOUE", 1);
                    }
                }
            }
	    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetInt("USOUE") == 0)
            {
                falasEntrou.SetActive(true);   
            }
            evento = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetInt("USOUE") == 0)
            {
                falasEntrou.SetActive(false); 
            }
            evento = false;
        }
    }
}
