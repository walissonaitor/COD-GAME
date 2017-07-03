using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eventos : MonoBehaviour {

    public bool evento = false;
    public int idEvento;
    public UIGamePlay uIGamePlay;
    public Text textos;

    // Use this for initialization
    void Start () {
        uIGamePlay = FindObjectOfType(typeof(UIGamePlay)) as UIGamePlay;
    }

    float tempo = 0;
    float duracao = 3;
    // Update is called once per frame
    void Update()
    {
        if (evento == true) {
            tempo += Time.deltaTime;
            if (tempo < duracao)
            {
                textos.gameObject.SetActive(true);
                textos.text = "Clique E para interagir com o NPC";
            }
            else if (tempo > duracao && tempo < duracao + 1)
            {
                textos.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                textos.gameObject.SetActive(false);
                uIGamePlay.EntrarQuest(idEvento-1);
                PlayerPrefs.SetInt("ULTIMAFASE", idEvento);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Player")
            {
            evento = true;
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            evento = false;
        }
    }
}
