using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ButtonManagement : MonoBehaviour {
    public Text playerDisplay;
	// Use this for initialization
	void Start () 
    {
		if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
        }
	}
	
    public void LoadSignInPage()
    {
        SceneManager.LoadScene("signIn");
    }

    public void LoadCreateAccountPage()
    {
        SceneManager.LoadScene("createAccount");
    }

    public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
   

}
