using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direcao
{
    NORTE,
    SUL,
    LESTE,
    OESTE
}

public class Programar : MonoBehaviour
{

    public InputField inputFieldMain;
    public InputField inputFieldFunc1;
    public InputField inputFieldFunc2;
    public Button botaoExecutar;
    public Button botaoParar;
    public GameObject canvas;
    public GameObject falaFim;
    public GameObject falaErro;
    private string [] comandosM, comandosF1, comandosF2;
    private int[] executados = {0,0,0};
    private bool executar = false;
    private Direcao direcao = Direcao.LESTE;
    private bool chegou = false;
    private GameController gameController;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        PlayerPrefs.SetFloat("PosicaoInicialX", transform.position.x);
        PlayerPrefs.SetFloat("PosicaoInicialY", transform.position.y);
        PlayerPrefs.SetFloat("PosicaoInicialZ", transform.position.z);
        executar = false;
    }

    int anteriorF1 = 0;
    int anteriorF2 = 0;
    int atual = 0;

    private Animator anim;

    private bool andando;
    private Vector2 posicaoParado;
    private Vector2 posicaoAndando;

    // Update is called once per frame
    void Update()
    {
        if (gameController.CurrentState == StateMachine.INQUEST)
        {
            if (executar == true)
            {
                inputFieldMain.interactable = false;
                inputFieldFunc1.interactable = false;
                inputFieldFunc2.interactable = false;
                switch (direcao)
                {
                    case Direcao.NORTE:
                        posicaoParado = new Vector2(0, 1);
                        break;
                    case Direcao.SUL:
                        posicaoParado = new Vector2(0, -1);
                        break;
                    case Direcao.LESTE:
                        posicaoParado = new Vector2(1, 0);
                        break;
                    case Direcao.OESTE:
                        posicaoParado = new Vector2(-1, 0);
                        break;
                }
                botaoExecutar.gameObject.SetActive(false);
                botaoParar.gameObject.SetActive(true);
                if (atual == 0)
                {
                    anim.SetBool("andando", andando);
                    anim.SetFloat("posicaoX", posicaoAndando.x);
                    anim.SetFloat("posicaoY", posicaoAndando.y);
                    anim.SetFloat("paradoX", posicaoParado.x);
                    anim.SetFloat("paradoY", posicaoParado.y);
                    if (executados[atual] < comandosM.Length)
                    {
                        switch (comandosM[executados[atual]])
                        {
                            case "Andar()":
                                Andar();
                                break;
                            case "Virar('Esquerda')":
                                Virar("Esquerda");
                                break;
                            case "Virar('Direita')":
                                Virar("Direita");
                                break;
                            case "Func1()":
                                if (atual == 1)
                                {
                                    executados[atual] = 0;
                                }
                                anteriorF1 = atual;
                                atual = 1;
                                break;
                            case "Func2()":
                                if (atual == 2)
                                {
                                    executados[atual] = 0;
                                }
                                anteriorF2 = atual;
                                atual = 2;
                                break;
                            case "Pegar()":
                                if (chegou == true)
                                {
                                    if (PlayerPrefs.GetInt("ULTIMAFASE") == 1)
                                    {
                                        canvas.GetComponent<UIGamePlay>().EntrarQuest(1);
                                        PlayerPrefs.SetInt("ULTIMAFASE", 2);
                                    }
                                    else if (PlayerPrefs.GetInt("ULTIMAFASE") == 2)
                                    {
                                        canvas.GetComponent<UIGamePlay>().EntrarQuest(2);
                                        PlayerPrefs.SetInt("ULTIMAFASE", 3);
                                    }
                                    else if (PlayerPrefs.GetInt("ULTIMAFASE") == 3)
                                    {
                                        falaFim.SetActive(true);
                                        PlayerPrefs.SetInt("ULTIMAFASE", 4);
                                    }
                                    executar = false;
                                }
                                else
                                {
                                    executados[atual]++;
                                }
                                break;
                            default:
                                if (atual == 1)
                                {
                                    executados[atual] = 0;
                                    atual = anteriorF1;
                                    executados[atual]++;
                                }
                                else if (atual == 2)
                                {
                                    executados[atual] = 0;
                                    atual = anteriorF2;
                                    executados[atual]++;
                                }
                                else
                                {
                                    executados[atual]++;
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                transform.position = new Vector3(PlayerPrefs.GetFloat("PosicaoInicialX"), PlayerPrefs.GetFloat("PosicaoInicialY"), PlayerPrefs.GetFloat("PosicaoInicialZ"));
                botaoExecutar.gameObject.SetActive(true);
                botaoParar.gameObject.SetActive(false);
                chegou = false;
                executados[0] = 0;
                executados[1] = 0;
                executados[2] = 0;
                inputFieldMain.interactable = true;
                inputFieldFunc1.interactable = true;
                inputFieldFunc2.interactable = true;
                direcao = Direcao.LESTE;
                anim.SetBool("andando", false);
                anim.SetFloat("paradoX", 1);
                anim.SetFloat("paradoY", 0);
            }
        }  
    }

    public void Parar()
    {
        executar = false;
    }

    public void Executar()
    {
        string textoM = inputFieldMain.text;
        textoM = textoM.Replace(" ", "");
        textoM = textoM.Replace("\n", "");
        textoM = textoM.Replace("\t", "");
        comandosM = textoM.Split(';');

        string textoF2 = inputFieldFunc2.text;
        textoF2 = textoF2.Replace(" ", "");
        textoF2 = textoF2.Replace("\n", "");
        textoF2 = textoF2.Replace("\t", "");
        comandosF2 = textoF2.Split(';');

        string textoF1 = inputFieldFunc1.text;
        textoF1 = textoF1.Replace(" ", "");
        textoF1 = textoF1.Replace("\n", "");
        textoF1 = textoF1.Replace("\t", "");
        comandosF1 = textoF1.Split(';');
        executar = !executar;
    }

    //int vetor = 0;

    private int vezes = 0;

    private void Virar(string lado)
    {
        if (lado.Equals("Direita"))
        {
            switch (direcao)
            {
                case Direcao.NORTE:
                    direcao = Direcao.LESTE;
                    break;
                case Direcao.SUL:
                    direcao = Direcao.OESTE;
                    break;
                case Direcao.LESTE:
                    direcao = Direcao.SUL;
                    break;
                case Direcao.OESTE:
                    direcao = Direcao.NORTE;
                    break;
            }
        }
        else if (lado.Equals("Esquerda"))
        {
            andando = false;
            switch (direcao)
            {
                case Direcao.NORTE:
                    direcao = Direcao.OESTE;
                    break;
                case Direcao.SUL:
                    direcao = Direcao.LESTE;
                    break;
                case Direcao.LESTE:
                    direcao = Direcao.NORTE;
                    break;
                case Direcao.OESTE:
                    direcao = Direcao.SUL;
                    break;
            }
        }
        executados[atual]++;
    }

    private void Andar()
    {
        if (vezes < 50)
        {
            if (vezes < 24)
            {
                andando = true;
                switch (direcao)
                {
                    case Direcao.NORTE:
                        transform.Translate(0, 0.05f, 0);
                        posicaoAndando = new Vector2(0, 1);
                        break;
                    case Direcao.SUL:
                        transform.Translate(0, -0.05f, 0);
                        posicaoAndando = new Vector2(0, -1);
                        break;
                    case Direcao.LESTE:
                        transform.Translate(0.05f, 0, 0);
                        posicaoAndando = new Vector2(1, 0);
                        break;
                    case Direcao.OESTE:
                        transform.Translate(-0.05f, 0, 0);
                        posicaoAndando = new Vector2(-1, 0);
                        break;
                }
            }else
            {
                andando = false;
            }
            vezes++;
        }
        else
        {
            executados[atual]++;
            vezes = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ColisaoDesafio")
        {
            falaErro.SetActive(true);
            executar = false;
        }

        else if (other.tag == "ColisaoFinal")
        {
            chegou = true;
        }
    }
}