using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Panda : MonoBehaviour {

    private Transform player;
    public bool podeAndar = true;
    public bool podeVoltar = true;
    private float horizontal;
    private float vertical;
    public float speed;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (PlayerPrefs.GetInt("SAVEATUAL") != 0)
        {
            transform.position = new Vector3(
                PlayerPrefs.GetFloat("XPANDAPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                PlayerPrefs.GetFloat("YPANDAPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL")),
                PlayerPrefs.GetFloat("ZPANDAPOSITIONSAVE" + PlayerPrefs.GetInt("SAVEATUAL"))
                );
        }
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Andar();
        Voltar();
    }

    void Voltar() {
        if (podeVoltar == true) {  
            if (horizontal > 0)
            {
                transform.position = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y, player.transform.position.z);
            }
            else if (horizontal < 0) {
                transform.position = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, player.transform.position.z);
            }
            else if (vertical > 0)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.5f, player.transform.position.z);
            }
            else if (vertical < 0)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
            }
        }
    }

    void Andar() {
        if (podeAndar == true)
        {
            
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerRadar")
        {
            podeAndar = false;
        }
        else if (other.tag == "PlayerRect") {
            podeVoltar = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerRadar")
        {
            podeAndar = true;
        }
        else if (other.tag == "PlayerRect")
        {
            podeVoltar = true;
        }
    }

}
