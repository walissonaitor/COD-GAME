using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateMachine
{
    STARTGAME,
    INGAME,
    PAUSED,
    INQUEST,
    INFALA
}

public class GameController : MonoBehaviour {

    private StateMachine stateMachine;

	// Use this for initialization
	void Start () {
        stateMachine = StateMachine.STARTGAME;
	}

    float tempo;
    float duracao = 3;
    public Text textos;
	
	// Update is called once per frame
	void Update () {
        currentStateMachine();
	}

    private void currentStateMachine()
    {
        switch (stateMachine)
        {
            case StateMachine.STARTGAME:
                {
                    StartGame();
                    break;
                }
            case StateMachine.INGAME:
                {
                    break;
                }
            case StateMachine.PAUSED:
                {
                    break;
                }
            case StateMachine.INQUEST:
                {
                    break;
                }
        }
    }

    public StateMachine CurrentState
    {
        get { return stateMachine; }
        set { stateMachine = value; }
    }

    public void StartGame()
    {
        CurrentState = StateMachine.INGAME;
    }

}
