#pragma strict

var comandos: int;
var codigo : String;
var inputField : UnityEngine.UI.InputField;
var executar : UnityEngine.UI.Text;
var executando;
var vezes = 0;
var executados = 0;
var direcao = 2;//1 - Norte, -1 - Sul, 2 - Leste, -2 - Oeste 

function Start () {
    PlayerPrefs.SetFloat("PosicaoInicialX", transform.position.x);
    PlayerPrefs.SetFloat("PosicaoInicialY", transform.position.y);
    PlayerPrefs.SetFloat("PosicaoInicialZ", transform.position.z);
    comandos = 0;
    executando = false;
}

function Andar () {

    if (vezes < 15)
    {
        if (vezes < 10)
        {
            switch (direcao)
            {
                case -1:
                    transform.Translate(0, -0.1, 0);
                    break;
                case 1:
                    transform.Translate(0, 0.1, 0);
                    break;
                case 2:
                    transform.Translate(0.1, 0, 0);
                    break;
                case -2:
                    transform.Translate(-0.1, 0, 0);
                    break;
            }
        }
        vezes++;
    }
    else
    {
        executados++;
        vezes = 0;
    }
}

function Update () {
    codigo = inputField.text;
    
        if(executando == true){
            inputField.interactable = false;
            executar.text = "Parar Execução!";
            if(PlayerPrefs.GetInt("errou") == 0) {
                try{
                    eval(codigo);
                }catch(err){
                    Debug.Log("Erro de sintaxe!");
                    executando = false;
                }
            }else{
                Debug.Log("Erro de lógica!");
            }
        }else{
            transform.position = new Vector3(PlayerPrefs.GetFloat("PosicaoInicialX"), PlayerPrefs.GetFloat("PosicaoInicialY"), PlayerPrefs.GetFloat("PosicaoInicialZ"));
            inputField.interactable = true;
            executar.text = "Executar!";
        }
    
}

function Executar() {
    executando = !executando;
}