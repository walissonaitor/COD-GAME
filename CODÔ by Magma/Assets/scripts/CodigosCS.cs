using System.Collections;
using System.Collections.Generic;
using UnityEngine. UI;
using UnityEngine;

public class CodigosCS : MonoBehaviour
{

    public InputField inputFieldMain;
    //public InputField inputFieldFunc1;
    //public InputField inputFieldFunc2;
    public Text botaoExecutar;
    public int nLinhas = 1;
    private string[] textoMain;
    private string[] textoFunc1;
    private string[] textoFunc2;
    private int executadosM = 0;
    private int executadosF1 = 0;
    private int executadosF2 = 0;
    private bool executar = false;
    private Direcao direcao = Direcao.LESTE;
    private bool caminhoEsquerda = false;
    private bool caminhoDireita = false;
    private bool caminhoFrente = false;
    private bool objetoEncontrado = false;
    private bool desafioConcluido = false;

    void Start()
    {
        PlayerPrefs.SetFloat("PosicaoInicialX", transform.position.x);
        PlayerPrefs.SetFloat("PosicaoInicialY", transform.position.y);
        PlayerPrefs.SetFloat("PosicaoInicialZ", transform.position.z);
        executar = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (executar == true)
        {
            botaoExecutar.text = "Parar Execução!";
            if (executadosM < textoMain.Length)
            {
                switch (textoMain[executadosM])
                {
                    case "Andar()":
                        AndarM();
                        break;
                    case "Virar('Esquerda')":
                        VirarM("Esquerda");
                        break;
                    case "Virar('Direita')":
                        VirarM("Direita");
                        break;
                    case "Func1()":
                        Func1M();
                        break;
                    case "Func2()":
                        Func2M();
                        break;
                    default:
                        executadosM++;
                        break;
                }
            }
        }
        else
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PosicaoInicialX"), PlayerPrefs.GetFloat("PosicaoInicialY"), PlayerPrefs.GetFloat("PosicaoInicialZ"));
            botaoExecutar.text = "Executar!";
            executadosM = 0;
            executadosF1 = 0;
            executadosF2 = 0;
            direcao = Direcao.LESTE;
        }
    }

    public void Executar()
    {
        string textoM = inputFieldMain.text;
        textoM = textoM.Replace(" ", "");
        textoM = textoM.Replace("\n", "");
        textoM = textoM.Replace("\t", "");
        textoMain = textoM.Split(';');

        /*string textoF1 = inputFieldFunc1.text;
        textoF1 = textoF1.Replace(" ", "");
        textoF1 = textoF1.Replace("\n", "");
        textoF1 = textoF1.Replace("\t", "");
        textoFunc1 = textoF1.Split(';');

        for (int i = 0; i < textoFunc1.Length; i++)
        {
            Debug.Log(i + " : " + textoFunc1[i]);
        }

        string textoF2 = inputFieldFunc2.text;
        textoF2 = textoF2.Replace(" ", "");
        textoF2 = textoF2.Replace("\n", "");
        textoF2 = textoF2.Replace("\t", "");
        textoFunc2 = textoF2.Split(';');

        for (int i = 0; i < textoFunc2.Length; i++)
        {
            Debug.Log(i + " : " + textoFunc2[i]);
        }*/

        executar = !executar;
    }

    private int vezes = 0;

    private void VirarM(string lado)
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
        executadosM++;
    }

    private void AndarM()
    {
        if (vezes < 25)
        {
            if (vezes < 10)
            {
                switch (direcao)
                {
                    case Direcao.NORTE:
                        transform.Translate(0, -0.1f, 0);
                        break;
                    case Direcao.SUL:
                        transform.Translate(0, 0.1f, 0);
                        break;
                    case Direcao.LESTE:
                        transform.Translate(0.1f, 0, 0);
                        break;
                    case Direcao.OESTE:
                        transform.Translate(-0.1f, 0, 0);
                        break;
                }
            }
            vezes++;
        }
        else
        {
            executadosM++;
            vezes = 0;
        }
    }

    private void VirarF1(string lado)
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
        executadosF1++;
    }

    private void AndarF1()
    {
        if (vezes < 25)
        {
            if (vezes < 10)
            {
                switch (direcao)
                {
                    case Direcao.NORTE:
                        transform.Translate(0, -0.1f, 0);
                        break;
                    case Direcao.SUL:
                        transform.Translate(0, 0.1f, 0);
                        break;
                    case Direcao.LESTE:
                        transform.Translate(0.1f, 0, 0);
                        break;
                    case Direcao.OESTE:
                        transform.Translate(-0.1f, 0, 0);
                        break;
                }
            }
            vezes++;
        }
        else
        {
            executadosF1++;
            vezes = 0;
        }
    }

    private void VirarF2(string lado)
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
        executadosF2++;
    }

    private void AndarF2()
    {
        if (vezes < 25)
        {
            if (vezes < 10)
            {
                switch (direcao)
                {
                    case Direcao.NORTE:
                        transform.Translate(0, -0.1f, 0);
                        break;
                    case Direcao.SUL:
                        transform.Translate(0, 0.1f, 0);
                        break;
                    case Direcao.LESTE:
                        transform.Translate(0.1f, 0, 0);
                        break;
                    case Direcao.OESTE:
                        transform.Translate(-0.1f, 0, 0);
                        break;
                }
            }
            vezes++;
        }
        else
        {
            executadosF2++;
            vezes = 0;
        }
    }

    private void Func1M()
    {
        if (executadosF1 < textoFunc1.Length)
        {
            //Debug.Log(textoMain[executadosM]);
            //Debug.Log("["+executados+"] - "+textoTratado[executados]);
            switch (textoFunc1[executadosF1])
            {
                case "Andar()":
                    AndarF1();
                    break;
                case "Virar('Esquerda')":
                    VirarF1("Esquerda");
                    break;
                case "Virar('Direita')":
                    VirarF1("Direita");
                    break;
                case "Func1()":
                    Func1M();
                    break;
                case "Func2()":
                    Func2M();
                    break;
                default:
                    executadosM++;
                    executadosF1 = 0;
                    break;
            }
        }
    }

    private void Func2M()
    {
        if (executadosF2 < textoFunc2.Length)
        {
            switch (textoFunc2[executadosF2])
            {
                case "Andar()":
                    AndarF2();
                    break;
                case "Virar('Esquerda')":
                    VirarF2("Esquerda");
                    break;
                case "Virar('Direita')":
                    VirarF2("Direita");
                    break;
                case "Func1()":
                    Func1M();
                    break;
                case "Func2()":
                    Func2M();
                    break;
                default:
                    executadosM++;
                    executadosF2 = 0;
                    break;
            }
        }
    }

    private void Func1F2()
    {
        if (executadosF1 < textoFunc1.Length)
        {
            //Debug.Log(textoMain[executadosM]);
            //Debug.Log("["+executados+"] - "+textoTratado[executados]);
            switch (textoFunc1[executadosF1])
            {
                case "Andar()":
                    AndarF1();
                    break;
                case "Virar('Esquerda')":
                    VirarF1("Esquerda");
                    break;
                case "Virar('Direita')":
                    VirarF1("Direita");
                    break;
                case "Func1()":
                    Func1F2();
                    break;
                case "Func2()":
                    Func2F2();
                    break;
                default:
                    executadosF2++;
                    executadosF1 = 0;
                    break;
            }
        }
    }

    private void Func2F2()
    {
        if (executadosF2 < textoFunc2.Length)
        {
            switch (textoFunc2[executadosF2])
            {
                case "Andar()":
                    AndarF2();
                    break;
                case "Virar('Esquerda')":
                    VirarF2("Esquerda");
                    break;
                case "Virar('Direita')":
                    VirarF2("Direita");
                    break;
                case "Func1()":
                    Func1F2();
                    break;
                case "Func2()":
                    Func2F2();
                    break;
                default:
                    executadosF1++;
                    executadosF2 = 0;
                    break;
            }
        }
    }
}