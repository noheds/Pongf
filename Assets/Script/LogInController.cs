using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;


public class LogInController : MonoBehaviour {

	public InputField user;
	public InputField pwdF;
	public Button registerbutton;
	public Text result;
	public Toggle onlyPlayer;

	private string userString;
	private string pwdString;
	DatabaseReference reference;
	// Use this for initialization


	void Start () {

		// Set up the Editor before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://pong-574e7.firebaseio.com/");

		// Get the root reference location of the database.
		 reference = FirebaseDatabase.DefaultInstance.RootReference;

		Button btn = registerbutton.GetComponent<Button>();

		btn.onClick.AddListener(delegate{CheckDB(userString,pwdString);});
	
	}
	
	// Update is called once per frame
	void Update () {
		
		userString = user.text;
		pwdString = pwdF.text;
		Debug.Log (userString);
		Debug.Log (pwdString);


	}


	public void CheckDB( string user,string pwd) {

		FirebaseDatabase.DefaultInstance
			.GetReference("users")
			.GetValueAsync().ContinueWith(task => {
				if (task.IsFaulted) {
					Debug.Log("Hubo un error");
					// Handle the error...
				}
				else if (task.IsCompleted) {
					DataSnapshot snapshot = task.Result;
					Debug.Log(snapshot);

					if (snapshot != null && snapshot.ChildrenCount > 0) {

						foreach (var childSnapshot in snapshot.Children) {
							var users = childSnapshot.Child ("username").Value.ToString (); 
							var password = childSnapshot.Child ("pwd").Value.ToString ();

							Debug.Log(users.ToString());
							Debug.Log(password.ToString());
							if(users == userString && password == pwdString){
								
								if(onlyPlayer.isOn){

									SceneManager.LoadScene(2);

								}else{


									SceneManager.LoadScene(1);
								}
							}else{

								result.text = "El usuario o la contraseña no coinciden con la base de datos";
							}

						}
					}
					}
			});
		Debug.Log("se ejecuto la query");

		}
}