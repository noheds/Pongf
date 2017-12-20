using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {


    public Rect position = new Rect(200, 50, 150, 25);
    public string text = "Inicia Sesion para jugar";
    public GUISkin skin = null;

    private void OnGUI() {
        GUI.skin = skin;
        GUI.Label(position, text);
    }
}
