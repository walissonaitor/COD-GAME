using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdaMovimentacao : MonoBehaviour {

    public float speed;
	private float horizontal;
	private float vertical;
    private GameController gameController;
    public GameObject controleFalasInicio;
    private string cenaAtual;
    private Animator anim;
    public GameObject barreira;

    private bool andando;
    private Vector2 posicaoParado;

    void Awake()
    {
        cenaAtual = SceneManager.GetActiveScene().name;
    }

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        if (PlayerPrefs.GetInt("SAVEATUAL") != 0)
        {
                    transform.position = new Vector3(
                    PlayerPrefs.GetFloat("XPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                    PlayerPrefs.GetFloat("YPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                    PlayerPrefs.GetFloat("ZPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL"))
                    );
            controleFalasInicio.SetActive(false);
        }
        else
        {
            controleFalasInicio.SetActive(true);
        }
        anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {

        if (gameController.CurrentState == StateMachine.INGAME)
        {
            Movimentacao();
        }
    }

    void Movimentacao()
    {
        andando = false;
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical > 0 || vertical < 0)
        {
            transform.Translate(0, vertical * Time.deltaTime * speed, 0);
            andando = true;
            posicaoParado = new Vector2(0, vertical);
        }

        else if (horizontal > 0 || horizontal < 0)
        {
            transform.Translate(horizontal * Time.deltaTime * speed, 0, 0);
            andando = true;
            posicaoParado = new Vector2(horizontal, 0);
        }
        
        anim.SetBool("andando", andando);
        anim.SetFloat("posicaoX", horizontal);
        anim.SetFloat("posicaoY", vertical);
        anim.SetFloat("paradoX", posicaoParado.x);
        anim.SetFloat("paradoY", posicaoParado.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barreira")
        {
            barreira.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Barreira")
        {
            barreira.SetActive(false);
        }
    }

}
