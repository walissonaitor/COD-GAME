using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    AudioSource audio;
    public bool fundo;

	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (fundo == true) {
            audio.volume = PlayerPrefs.GetFloat("VOLUMEMUSICA");
        }else
        {
            audio.volume = PlayerPrefs.GetFloat("VOLUMESOM");
        }
	}
}
