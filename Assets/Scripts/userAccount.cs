using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userAccount : MonoBehaviour
{

    public string username;
    public string password;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void finishSignIn()
    {
        getUsername();
        getPassword();
    }
    public void getUsername()
    {
        username = GameObject.Find("userNameInput").GetComponent<Text>().text;
        Debug.Log("username is: " + username);
    }
    public void getPassword()
    {
        password = GameObject.Find("passwordInput").GetComponent<Text>().text;
        Debug.Log("password is: " + password);
    }

}
