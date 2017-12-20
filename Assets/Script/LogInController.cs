using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class LogInController : MonoBehaviour {

	public InputField user;
	public InputField pwdF;
	public Button registerbutton;

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
							var name = childSnapshot.Child ("name").Value.ToString (); 

							//text.text = name.ToString();
							Debug.Log(name.ToString());


						}
					}
					}
			});
		Debug.Log("se ejecuto la query");

		}
}