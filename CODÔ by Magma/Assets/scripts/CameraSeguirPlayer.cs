using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguirPlayer : MonoBehaviour {

    // Use this for initialization
    private Transform target;
    public float speed;
    private Vector3 positionTarget;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (gameController.CurrentState == StateMachine.INGAME)
        {
            positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, speed);
            transform.position = tempPosition;
        }else if (gameController.CurrentState == StateMachine.INQUEST)
        {
            transform.position = new Vector3(0,0,-10);
        }
    }
}
