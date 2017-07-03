using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MENU : MonoBehaviour
{

    [Header("Menu Principal")]
    public Button BotaoJogar;
    public Button BotaoOpcoes;
    public Button BotaoCarregar;
    public Button BotaoCreditos;
    public Button BotaoSair;
    [Space(20)]

    [Header("NovoJogo")]
    public string nomeCenaJogo = "CENA1";
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

    [Header("Créditos")]
    public GameObject CreditosPainel;
    public Button BotaoVoltarCreditos;
    [Space(20)]

    [Header("Sair")]
    public GameObject SairPainel;
    public Button BotaoSairSim;
    public Button BotaoSairNao;

    [Header("Botões")]
    public GameObject nome1;
    public GameObject nome2;
    public GameObject nome3;
    public GameObject nome4;
    public GameObject nome5;
    [Space(20)]

    private string nomeDaCena;
    private float VOLUMEMUSICA;
    private float VOLUMESOM;
    private int qualidadeGrafica, modoJanelaAtivo, resolucaoSalveIndex;
    private bool telaCheiaAtivada;
    private Resolution[] resolucoesSuportadas;

    void Start()
    {
        Opcoes(false);
        Creditos(false);
        Sair(false);
        Carregar(false);
        /*
        ChecarResolucoes();
        AjustarQualidades();
        */
        //
        /*
        if (PlayerPrefs.HasKey("RESOLUCAO"))
        {
            int numResoluc = PlayerPrefs.GetInt("RESOLUCAO");
            if (resolucoesSuportadas.Length <= numResoluc)
            {
                PlayerPrefs.DeleteKey("RESOLUCAO");
            }
        }*/
        //
        nomeDaCena = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Time.timeScale = 1;
        //
        BarraVolumeMusica.minValue = 0;
        BarraVolumeMusica.maxValue = 1;
        BarraVolumeSom.minValue = 0;
        BarraVolumeSom.maxValue = 1;

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
        if (PlayerPrefs.HasKey("VOLUMESOM"))
        {
            VOLUMESOM = PlayerPrefs.GetFloat("VOLUMESOM");
            BarraVolumeSom.value = VOLUMESOM;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUMEMUSICA", 1);
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
        //========RESOLUCOES========//
        if (modoJanelaAtivo == 1)
        {
            telaCheiaAtivada = false;
        }
        else
        {
            telaCheiaAtivada = true;
        }
        /*
        if (PlayerPrefs.HasKey("RESOLUCAO"))
        {
            resolucaoSalveIndex = PlayerPrefs.GetInt("RESOLUCAO");
            Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width, resolucoesSuportadas[resolucaoSalveIndex].height, telaCheiaAtivada);
            Resolucoes.value = resolucaoSalveIndex;
        }
        else
        {
            resolucaoSalveIndex = (resolucoesSuportadas.Length - 1);
            Screen.SetResolution(resolucoesSuportadas[resolucaoSalveIndex].width, resolucoesSuportadas[resolucaoSalveIndex].height, telaCheiaAtivada);
            PlayerPrefs.SetInt("RESOLUCAO", resolucaoSalveIndex);
            Resolucoes.value = resolucaoSalveIndex;
        }
        //=========QUALIDADES=========//
        if (PlayerPrefs.HasKey("qualidadeGrafica"))
        {
            qualidadeGrafica = PlayerPrefs.GetInt("qualidadeGrafica");
            QualitySettings.SetQualityLevel(qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }
        else
        {
            QualitySettings.SetQualityLevel((QualitySettings.names.Length - 1));
            qualidadeGrafica = (QualitySettings.names.Length - 1);
            PlayerPrefs.SetInt("qualidadeGrafica", qualidadeGrafica);
            Qualidades.value = qualidadeGrafica;
        }*/

        // =========SETAR BOTOES==========//
        BotaoJogar.onClick = new Button.ButtonClickedEvent();
        BotaoCarregar.onClick = new Button.ButtonClickedEvent();
        BotaoCreditos.onClick = new Button.ButtonClickedEvent();
        BotaoOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoSair.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarOpcoes.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarCreditos.onClick = new Button.ButtonClickedEvent();
        BotaoSalvarPref.onClick = new Button.ButtonClickedEvent();
        BotaoSairSim.onClick = new Button.ButtonClickedEvent();
        BotaoSairNao.onClick = new Button.ButtonClickedEvent();
        BotaoSave1.onClick = new Button.ButtonClickedEvent();
        BotaoSave2.onClick = new Button.ButtonClickedEvent();
        BotaoSave3.onClick = new Button.ButtonClickedEvent();
        BotaoVoltarCarregar.onClick = new Button.ButtonClickedEvent();

        BotaoVoltarCarregar.onClick.AddListener(() => Carregar(false));
        BotaoJogar.onClick.AddListener(() => Jogar(0));
        BotaoCarregar.onClick.AddListener(() => Carregar(true));
        BotaoOpcoes.onClick.AddListener(() => Opcoes(true));
        BotaoVoltarOpcoes.onClick.AddListener(() => Opcoes(false));
        BotaoSalvarPref.onClick.AddListener(() => SalvarPreferencias());
        BotaoCreditos.onClick.AddListener(() => Creditos(true));
        BotaoVoltarCreditos.onClick.AddListener(() => Creditos(false));
        BotaoSair.onClick.AddListener(() => Sair(true));
        BotaoSairSim.onClick.AddListener(() => Application.Quit());
        BotaoSairNao.onClick.AddListener(() => Sair(false));
        BotaoSave1.onClick.AddListener(() => Jogar(1));
        BotaoSave2.onClick.AddListener(() => Jogar(2));
        BotaoSave3.onClick.AddListener(() => Jogar(3));
    }
    /*
    //=========VOIDS DE CHECAGEM==========//
    private void ChecarResolucoes()
    {
        Resolution[] resolucoesSuportadas = Screen.resolutions;
        Resolucoes.options.Clear();
        for (int y = 0; y < resolucoesSuportadas.Length; y++)
        {
            Resolucoes.options.Add(new Dropdown.OptionData() { text = resolucoesSuportadas[y].width + "x" + resolucoesSuportadas[y].height });
        }
        Resolucoes.captionText.text = "Resolucao";
    }
    private void AjustarQualidades()
    {
        string[] nomes = QualitySettings.names;
        Qualidades.options.Clear();
        for (int y = 0; y < nomes.Length; y++)
        {
            Qualidades.options.Add(new Dropdown.OptionData() { text = nomes[y] });
        }
        Qualidades.captionText.text = "Qualidade";
    }*/
    private void Carregar(bool ativarOP)
    {
        PainelCarregar.gameObject.SetActive(ativarOP);
    }
    private void Opcoes(bool ativarOP)
    {
        OpcoesPainel.gameObject.SetActive(ativarOP);
        BarraVolumeMusica.gameObject.SetActive(ativarOP);
        BarraVolumeSom.gameObject.SetActive(ativarOP);
        CaixaModoJanela.gameObject.SetActive(ativarOP);
        //Resolucoes.gameObject.SetActive(ativarOP);
        //Qualidades.gameObject.SetActive(ativarOP);
        BotaoVoltarOpcoes.gameObject.SetActive(ativarOP);
        BotaoSalvarPref.gameObject.SetActive(ativarOP);
    }
    private void Creditos(bool ativarC)
    {
        BotaoVoltarCreditos.gameObject.SetActive(ativarC);
        CreditosPainel.gameObject.SetActive(ativarC);
    }

    private void Sair(bool ativarS)
    {
        SairPainel.gameObject.SetActive(ativarS);
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
        //PlayerPrefs.SetInt("qualidadeGrafica", Qualidades.value);
        PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
        //PlayerPrefs.SetInt("RESOLUCAO", Resolucoes.value);
        //resolucaoSalveIndex = Resolucoes.value;
        AplicarPreferencias();
    }
    private void AplicarPreferencias()
    {
        VOLUMEMUSICA = PlayerPrefs.GetFloat("VOLUMEMUSICA");
        VOLUMESOM = PlayerPrefs.GetFloat("VOLUMESOM");
    }

    //===========VOIDS NORMAIS=========//
    void Update()
    {
        if (SceneManager.GetActiveScene().name != nomeDaCena)
        {
            Destroy(gameObject);
        }
    }
    public void Jogar(int idSave)
    {
        if (idSave == 0)
        {
            PlayerPrefs.SetInt("ULTIMAFASE", 0);
        }
        PlayerPrefs.SetInt("SAVEATUAL", idSave);
        SceneManager.LoadScene(nomeCenaJogo);
    }
}