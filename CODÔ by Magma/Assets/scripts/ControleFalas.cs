using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFalas : MonoBehaviour {

    public GameObject[] falas;
    public int id = 0;
    private GameController gameController;
    public Button passar;
    private StateMachine status;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < falas.Length; i++)
        {
            falas[i].SetActive(false);
        }
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        mostrarFala();

        status = gameController.CurrentState;
        passar.onClick = new Button.ButtonClickedEvent();
        passar.onClick.AddListener(() => mostrarFala());
        gameController.CurrentState = StateMachine.INFALA;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void mostrarFala()
    {
        for (int i = 0; i < falas.Length; i++)
        {
            falas[i].SetActive(false);
        }

        if (id < falas.Length)
        {
            falas[id].SetActive(true);
            id++;
            gameController.CurrentState = StateMachine.INFALA;
        }
        else
        {
            gameController.CurrentState = status;
            gameObject.SetActive(false);
            id = 0;
        }
    }

}
