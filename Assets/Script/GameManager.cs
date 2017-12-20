using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    GameObject Ball;
    public GUISkin layout;

    GameObject theBall;
    // Use this for initialization
    void Start () {
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //Suma puntos de acuerdo a la pared que detecte collision
    public static void Score(string wallID){
        if (wallID == "RightWall"){
            PlayerScore1++;
        }
        else{
            PlayerScore2++;
        }
    }

    /// <summary>
    /// Checa constantemente si ocurre algun evento de puntaje y manda a llamar la funcion para instaciar otra bola
    /// Actualiza el puntaje a nivel de GUI
    /// Da la opcion a reiniciar el juego al final de la partida
    /// </summary>
    
    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")){

            PlayerScore1 = 0;
            PlayerScore2 = 0;
            Ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 15){

            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            Ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 15){

            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            Ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
