using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {

    [Header("Health Settings")]
    public int health = 0;
    [Space(10)]
    public int maxHealth = 100;
    [HideInInspector]
    public int p = 5;
    [Range(1,10)]
    public int i;
    [TextArea]
    public string MyTextArea;
    [Tooltip("Health value between 0 and 100.")]
    public int oi = 0;

    [GUITarget(0, 1)]
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 100), "Visible on TV and Wii U GamePad only");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
