using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class UIGamePlay : MonoBehaviour {

    public string nomeCenaJogo = "CENA1";

    [Header("Game Play")]
    public Button BotaoPause;
    [Space(20)]

    [Header("Mapa")]
    [Space(20)]

    [Header("Diário")]
    [Space(20)]

    [Header("Pause")]
    public GameObject PausePainel;
    public Button BotaoContinuar;
    public Button BotaoCarregar;
    public Button BotaoSalvar;
    public Button BotaoOpcoes;
    public Button BotaoMenu;
    [Space(20)]

    [Header("Opções")]
    public GameObject OpcoesPainel;
    public Slider BarraVolumeSom;
    public Slider BarraVolumeMusica;
    public Toggle CaixaModoJanela;
    public Button BotaoVoltarOpcoes;
    public Button BotaoSalvarPref;
    [Space(20)]

    [Header("Carregar")]
    public GameObject PainelCarregar;
    public Button BotaoSave1;
    public Button BotaoSave2;
    public Button BotaoSave3;
    public Button BotaoVoltarCarregar;
    [Space(20)]

    [Header("Salvar")]
    public GameObject PainelSalvar;
    public Button BotaoSalvar1;
    public Button BotaoSalvar2;
    public Button BotaoSalvar3;
    public Button BotaoVoltarSalvar;
    [Space(20)]

    [Header("Paineis")]
    public GameObject painelQuest;
    public GameObject painelGame;
    public Button executar;
    public Button parar;
    public Button voltar;
    public GameObject voltarPainel;
    public Button voltarSim;
    public Button voltarNao;
    public InputField textosM, textosF1, textosF2;
    public GameObject lateral;
    [Space(20)]

    [Header("Sair")]
    public GameObject SairPainel;
    public Button BotaoSairSim;
    public Button BotaoSairNao;
    [Space(20)]

    [Header("Salvar")]
    public GameObject SalPainel;
    public Button BotaoSalSim;
    public Button BotaoSalNao;
    [Space(20)]

    [Header("Carregar")]
    public GameObject CarPainel;
    public Button BotaoCarSim;
    public Button BotaoCarNao;

    public Text salvoPrefText;
    public Text salvoText;
    private bool salvo;
    private bool salvoPref;

    public GameObject mapa2;
    public GameObject [] mapa1;

    public GameObject Quest1;
    public GameObject Quest2;
    public GameObject Quest3;

    public Text comandos;

    private string nomeDaCena;
    private float VOLUMESOM;
    private float VOLUMEMUSICA;
    private int modoJanelaAtivo;
    private bool telaCheiaAtivada;
    public Transform player , panda;
    private GameController gameController;
    private bool pausado = false;
    private bool naquest = false;
    public Transform camera;
    float xc, yc;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {

        Opcoes(false);
        Pausar(false);
        Carregar(false);
        Salvar(false);
        Sair(false);
        Car(false,0);
        Sal(false,0);
        SairQuest();

        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //panda = GameObject.FindGameObjectWithTag("Panda").transform;

        nomeDaCena = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Time.timeScale = 1;
        //
        BarraVolumeMusica.minValue = 0;
        BarraVolumeMusica.maxValue = 1;

        //=============== SAVES===========//
        if (PlayerPrefs.HasKey("VOLUMEMUSICA"))
        {
            VOLUMEMUSICA = PlayerPrefs.GetFloat("VOLUMEMUSICA");
            BarraVolumeMusica.value = VOLUMEMUSICA;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUMEMUSICA", 1);
            BarraVolumeMusica.value = 1;
        }

        //
        BarraVolumeSom.minValue = 0;
        BarraVolumeSom.maxValue = 1;

        //=============== SAVES===========//
        if (PlayerPrefs.HasKey("VOLUMESOM"))
        {
            VOLUMESOM = PlayerPrefs.GetFloat("VOLUMESOM");
            BarraVolumeSom.value = VOLUMESOM;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUMESOM", 1);
            BarraVolumeSom.value = 1;
        }

        //=============MODO JANELA===========//
        if (PlayerPrefs.HasKey("modoJanela"))
        {
            modoJanelaAtivo = PlayerPrefs.GetInt("modoJanela");
            if (modoJanelaAtivo == 1)
            {
                Screen.fullScreen = false;
                CaixaModoJanela.isOn = true;
            }
            else
            {
                Screen.fullScreen = true;
                CaixaModoJanela.isOn = false;
            }
        }
        else
        {
            modoJanelaAtivo = 0;
            PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
            CaixaModoJanela.isOn = false;
            Screen.fullScreen = true;
        }

        // =========SETAR BOTOES==========//
        BotaoContinuar.onClick = new Button.ButtonClickedEvent();
        BotaoPause.onClick = new Button.ButtonClickedEvent();
        BotaoOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoMenu.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
        BotaoSave1.onClick = new Button.ButtonClickedEvent();
        BotaoSave2.onClick = new Button.ButtonClickedEvent();
        BotaoSave3.onClick = new Button.ButtonClickedEvent();
        BotaoSalvar1.onClick = new Button.ButtonClickedEvent();
        BotaoSalvar.onClick = new Button.ButtonClickedEvent();
        BotaoSalvar2.onClick = new Button.ButtonClickedEvent();
        BotaoSalvar3.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarCarregar.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarSalvar.onClick = new Button.ButtonClickedEvent();
        BotaoSave1.onClick = new Button.ButtonClickedEvent();
        BotaoSave2.onClick = new Button.ButtonClickedEvent();
        BotaoSairSim.onClick = new Button.ButtonClickedEvent();
        BotaoSairNao.onClick = new Button.ButtonClickedEvent();
        BotaoSalSim.onClick = new Button.ButtonClickedEvent();
        BotaoSalNao.onClick = new Button.ButtonClickedEvent();
        voltarNao.onClick = new Button.ButtonClickedEvent();
        voltarSim.onClick = new Button.ButtonClickedEvent();
        voltar.onClick = new Button.ButtonClickedEvent();

        voltarSim.onClick.AddListener(() => SairQuest());
        voltarSim.onClick.AddListener(() => Voltar(false));
        voltar.onClick.AddListener(() => Voltar(true));

        BotaoVoltarCarregar.onClick.AddListener(() => Carregar(false));
        BotaoVoltarSalvar.onClick.AddListener(() => Salvar(false));
        BotaoSalvar.onClick.AddListener(() => Salvar(true));
        BotaoContinuar.onClick.AddListener(() => Pausar(false));
        BotaoPause.onClick.AddListener(() => Pausar(true));
        BotaoCarregar.onClick.AddListener(() => Carregar(true));
        BotaoOpcoes.onClick.AddListener(() => Opcoes(true));
        BotaoVoltarOpcoes.onClick.AddListener(() => Opcoes(false));
        BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());
        BotaoMenu.onClick.AddListener(() => Sair(true));
        BotaoSave1.onClick.AddListener(() => Car(true,1));
        BotaoSave2.onClick.AddListener(() => Car(true,2));
        BotaoSave3.onClick.AddListener(() => Car(true,3));

        BotaoCarSim.onClick.AddListener(() => Jogar(c));
        BotaoCarNao.onClick.AddListener(() => Car(false, 0));

        BotaoSalvar1.onClick.AddListener(() => Sal(true,1));
        BotaoSalvar2.onClick.AddListener(() => Sal(true,2));
        BotaoSalvar3.onClick.AddListener(() => Sal(true,3));
        BotaoSairSim.onClick.AddListener(() => VoltarMenu());
        BotaoSairNao.onClick.AddListener(() => Sair(false));
        BotaoSalSim.onClick.AddListener(() => Salvar(s));
        BotaoSalNao.onClick.AddListener(() => Sal(false, 0));
    }
    
    //=========VOIDS DE SALVAMENTO==========//
    private void SalvarPreferencias()
    {
        if (CaixaModoJanela.isOn == true)
        {
            modoJanelaAtivo = 1;
            telaCheiaAtivada = false;
        }
        else
        {
            modoJanelaAtivo = 0;
            telaCheiaAtivada = true;
        }
        PlayerPrefs.SetFloat("VOLUMESOM", BarraVolumeSom.value);
        PlayerPrefs.SetFloat("VOLUMEMUSICA", BarraVolumeMusica.value);
        PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
        AplicarPreferencias();
        StartCoroutine("SalvoPref");
    }
    private void AplicarPreferencias()
    {
        VOLUMESOM = PlayerPrefs.GetFloat("VOLUMESOM");
        VOLUMEMUSICA = PlayerPrefs.GetFloat("VOLUMEMUSICA");
        if (PlayerPrefs.HasKey("modoJanela"))
        {
            modoJanelaAtivo = PlayerPrefs.GetInt("modoJanela");
            if (modoJanelaAtivo == 1)
            {
                Screen.fullScreen = false;
                CaixaModoJanela.isOn = true;
            }
            else
            {
                Screen.fullScreen = true;
                CaixaModoJanela.isOn = false;
            }
        }
        else
        {
            modoJanelaAtivo = 0;
            PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
            CaixaModoJanela.isOn = false;
            Screen.fullScreen = true;
        }
    }

    private void Opcoes(bool ativarOP)
    {
        OpcoesPainel.gameObject.SetActive(ativarOP);
        BarraVolumeMusica.gameObject.SetActive(ativarOP);
        BarraVolumeSom.gameObject.SetActive(ativarOP);
        CaixaModoJanela.gameObject.SetActive(ativarOP);
        BotaoVoltarOpcoes.gameObject.SetActive(ativarOP);
        BotaoSalvarPref.gameObject.SetActive(ativarOP);
    }

    private void Pausar(bool pausar) {
            PausePainel.gameObject.SetActive(pausar);
            BotaoContinuar.gameObject.SetActive(pausar);
            BotaoCarregar.gameObject.SetActive(pausar);
            BotaoOpcoes.gameObject.SetActive(pausar);
            BotaoMenu.gameObject.SetActive(pausar);
            pausado = pausar;
    }

    private void Carregar(bool ativarOP)
    {
        PainelCarregar.gameObject.SetActive(ativarOP);
        Pausar(false);
    }

    private void Salvar(bool ativarOP)
    {
        PainelSalvar.gameObject.SetActive(ativarOP);
        Pausar(false);
    }

    private void VoltarMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void EntrarQuest(int idQuest)
    {
        xc = player.position.x;
        yc = player.position.y;
        naquest = true;
        executar.gameObject.SetActive(true);
        parar.gameObject.SetActive(true);
        voltar.gameObject.SetActive(true);
        textosM.gameObject.SetActive(true);
        textosF2.gameObject.SetActive(true);
        textosF1.gameObject.SetActive(true);
        painelGame.SetActive(false);
        painelQuest.SetActive(true);
        BotaoPause.gameObject.SetActive(false);
        lateral.gameObject.SetActive(true);
        mapa2.SetActive(false);
        for(int i = 0; i < mapa1.Length; i++)
        {
            mapa1[i].SetActive(false);
        }
        mapa1[idQuest].SetActive(true);

        if (idQuest == 0)
        {
            Quest1.SetActive(true);
            Quest2.SetActive(false);
            Quest3.SetActive(false);
            comandos.text = "Seus Comandos:\n* Andar();\n*Pegar(); ";
        } else if (idQuest == 1)
        {
            Quest1.SetActive(false);
            Quest2.SetActive(true);
            Quest3.SetActive(false);
            comandos.text = "Seus Comandos:\n* Andar();\n*Virar('Esquerda');\n*Virar('Direita');\n*Pegar(); ";
        } else if (idQuest == 2)
        {
            Quest1.SetActive(false);
            Quest2.SetActive(false);
            Quest3.SetActive(true);
            comandos.text = "Seus Comandos:\n* Andar();\n*Virar('Esquerda');\n*Virar('Direita');\n*Pegar(); ";
        }

    }

    public void Voltar(bool vol) {
        voltarPainel.SetActive(vol);
    }

    public void SairQuest()
    {
        BotaoPause.gameObject.SetActive(true);
        naquest = false;
        lateral.gameObject.SetActive(false);
        executar.gameObject.SetActive(false);
        parar.gameObject.SetActive(false);
        voltar.gameObject.SetActive(false);
        textosM.gameObject.SetActive(false);
        textosF1.gameObject.SetActive(false);
        textosF2.gameObject.SetActive(false);
        painelQuest.SetActive(false);
        painelGame.SetActive(true);
        mapa2.SetActive(true);
        camera.position = new Vector3(xc, yc, camera.position.z);
        Quest1.SetActive(false);
        Quest2.SetActive(false);
        Quest3.SetActive(false);
        for (int i = 0; i < mapa1.Length; i++)
        {
            mapa1[i].SetActive(false);
        }
    }

    private void Salvar(int id)
    {
        if (PlayerPrefs.GetInt("ULTIMAFASE") >= PlayerPrefs.GetInt("FASESAVE"+id))
        {
            PlayerPrefs.SetInt("FASESAVE" + id, PlayerPrefs.GetInt("ULTIMAFASE"));
        }
        PlayerPrefs.SetInt("STATUSSAVE" + id, 1);
        PlayerPrefs.SetFloat("XPOSITIONSAVE" + id, player.transform.position.x);
        PlayerPrefs.SetFloat("YPOSITIONSAVE" + id, player.transform.position.y);
        PlayerPrefs.SetFloat("ZPOSITIONSAVE" + id, player.transform.position.z);
        PlayerPrefs.SetFloat("XPANDAPOSITIONSAVE" + id, panda.transform.position.x);
        PlayerPrefs.SetFloat("YPANDAPOSITIONSAVE" + id, panda.transform.position.y);
        PlayerPrefs.SetFloat("ZPANDAPOSITIONSAVE" + id, panda.transform.position.z);
        PlayerPrefs.SetString("NAMESAVE" + id, "Missão");
        PlayerPrefs.SetString("TIMESAVE" + id, DateTime.Now.ToShortTimeString());
        PlayerPrefs.SetString("DATESAVE" + id, DateTime.Now.Day.ToString() + "/" +
                                                    DateTime.Now.Month.ToString() + "/" +
                                                    DateTime.Now.Year.ToString()
                                                    );
        Sal(false, 1);
        StartCoroutine("Salvo");
    }

    public void Jogar(int idSave)
    {
        PlayerPrefs.SetInt("SAVEATUAL", idSave);
        Carregar(false);
        SceneManager.LoadScene(nomeCenaJogo);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameController.CurrentState == StateMachine.INQUEST)
            {
                if(voltarPainel.activeSelf == true)
                {
                    Voltar(false);
                }else
                {
                    Voltar(true);
                }
            }else
            {
                if(pausado == true)
                {
                    Pausar(false);
                }else
                {
                    Pausar(true);
                }
            }
        }

        if (SceneManager.GetActiveScene().name != nomeDaCena)
        {
            Destroy(gameObject);
        }
        if (pausado == true)
        {    
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pausar(true);
            }
            
            gameController.CurrentState = StateMachine.PAUSED;
        }else if (naquest == true)
        {
            gameController.CurrentState = StateMachine.INQUEST;
        }
        else
        {
            gameController.CurrentState = StateMachine.INGAME;
        }
    }

    private void Sair(bool ativarS)
    {
        SairPainel.gameObject.SetActive(ativarS);
    }

    int s = 0;
    int c = 0;

    private void Sal(bool ativarS, int s)
    {
        if (ativarS == true)
        {
            this.s = s;
            if (PlayerPrefs.GetInt("STATUSSAVE" + s) == 1)
            {
                SalPainel.gameObject.SetActive(true);
            }
            else
            {
                Salvar(s);
            }
        }else
        {
            SalPainel.gameObject.SetActive(false);
        }
    }

    private void Car(bool ativarS, int c)
    {
        this.c = c;
        CarPainel.gameObject.SetActive(ativarS);
    }

    IEnumerator Salvo()
    {
        salvoText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        salvo = false;
        salvoText.gameObject.SetActive(false);
    }

    IEnumerator SalvoPref()
    {
        salvoPrefText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        salvoPref = false;
        salvoPrefText.gameObject.SetActive(false);
    }

}
