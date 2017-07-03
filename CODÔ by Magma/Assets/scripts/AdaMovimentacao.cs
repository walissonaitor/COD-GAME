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
    private string cenaAtual;
    private Animator anim;
    public Text textos;

    private bool andando;
    private Vector2 posicaoParado;

    void Awake()
    {
        cenaAtual = SceneManager.GetActiveScene().name;
    }

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        if(PlayerPrefs.GetInt("SAVEATUAL") != 0)
        {
                    transform.position = new Vector3(
                    PlayerPrefs.GetFloat("XPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                    PlayerPrefs.GetFloat("YPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                    PlayerPrefs.GetFloat("ZPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL"))
                    );
        }
        anim = GetComponent<Animator>();
        tempo = Time.deltaTime;
	}

    float tempo = 0;
    float duracao = 3;

	// Update is called once per frame
	void Update () {
        tempo += Time.deltaTime;
        if (PlayerPrefs.GetInt("SAVEATUAL") == 0)
        {
            if (tempo < duracao)
            {
                textos.gameObject.SetActive(true);
                textos.text = "Use as teclas W, S, A e D \n para se movimentar pelo mapa";
            }else if(tempo > duracao && tempo < duracao+1)
            {
                textos.gameObject.SetActive(false);
            }
        }
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

        if (horizontal > 0 || horizontal < 0)
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
}
