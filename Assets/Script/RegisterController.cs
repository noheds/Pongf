using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class User {
	public string username;
	public string pwd;

	public User() {
	}

	public User(string username, string pwd) {
		this.username = username;
		this.pwd = pwd;
	}

}

public class RegisterController : MonoBehaviour {

	public InputField user;
	public InputField paswd;
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

		btn.onClick.AddListener(delegate{writeNewUser(userString,userString,pwdString);});


	
	}
	
	// Update is called once per frame
	void Update () {
		
		userString = user.text;
		pwdString = paswd.text;

		Debug.Log (userString);
		Debug.Log (pwdString);

	}

	public void LoadScene(int level)
	{
		
		Application.LoadLevel(level);
	}

	public void writeNewUser(string userId, string name, string password) {
		User user = new User(name, password);
		string json = JsonUtility.ToJson(user);

		Debug.Log (name);
		Debug.Log (password);

		reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
		Debug.Log("se ejecuto la query");

	}
}
