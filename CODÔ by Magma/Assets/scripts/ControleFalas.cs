using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFalas : MonoBehaviour {

    public string[] falas;
    public string[] nomes;
    public Color[] cores;
    public Text nomeText;
    public Text falaText;
    public int id = 0;
    private GameController gameController;
    public Button passar;

    // Use this for initialization
    void Start ()
    {  
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        passar.onClick = new Button.ButtonClickedEvent();
        passar.onClick.AddListener(() => mostrarFala());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameController.CurrentState != StateMachine.PAUSED)
        {
            nomeText.fontSize = 20;
            falaText.fontSize = 20;
            nomeText.resizeTextMaxSize = 20;
            falaText.resizeTextMaxSize = 20;
            nomeText.text = nomes[id];
            falaText.text = falas[id];
            nomeText.color = cores[id]; 
        }
    }

    public void mostrarFala()
    {
        if (id < (falas.Length-1))
        {
            id++;
        }
        else
        { 
            gameObject.SetActive(false);
            id = 0;
        }
    }

}
