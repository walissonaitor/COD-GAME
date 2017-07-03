using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CarregarGame : MonoBehaviour {

    public int idSave;
    public int i;
    public Button Botao;
    public Text id;
    public Text textName;
    public Text textTime;
    public Text textDate;

    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {

        if (i == 0)
        {
            if (PlayerPrefs.GetInt("STATUSSAVE" + idSave) != 1)
            {
                textName.text = "???";
                textDate.text = "";
                textTime.text = "";
                Botao.interactable = false;
            }
            else
            {
                int s = PlayerPrefs.GetInt("FASESAVE" + idSave);
                textName.text = PlayerPrefs.GetString("NAMESAVE" + idSave);
                textName.text = textName.text + " - " + s;
                textDate.text = PlayerPrefs.GetString("DATESAVE" + idSave);
                textTime.text = PlayerPrefs.GetString("TIMESAVE" + idSave);
                Botao.interactable = true;
            }
        }else
        {
            if (PlayerPrefs.GetInt("STATUSSAVE" + idSave) != 1)
            {
                textName.text = "???";
                textDate.text = "";
                textTime.text = "";
            }
            else
            {
                int s = PlayerPrefs.GetInt("FASESAVE" + idSave);
                textName.text = PlayerPrefs.GetString("NAMESAVE" + idSave);
                textName.text = textName.text + " - " + s;
                textDate.text = PlayerPrefs.GetString("DATESAVE" + idSave);
                textTime.text = PlayerPrefs.GetString("TIMESAVE" + idSave);
            }
        }
	}
}
