using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoginManagement : MonoBehaviour
{
    public static string username;
    public static string password;
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;



    public void CallLogin()
    {
        StartCoroutine(Login());

    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost:81/SI_BoardGame/login.php", form);

        yield return www;
        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[2]);
            SceneManager.LoadScene("WelcomePage");

        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
    // Use this for initialization


    public void finishSignIn()
    {
        getUsername();
        getPassword();
        SceneManager.LoadScene("boardGameSetUp");
    }
    
    public void forgotPassword()
    {
        SceneManager.LoadScene("forgotPassword");
    }

       public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
    public void getUsername()
    {
        username = GameObject.Find("userNameInput").GetComponent<Text>().text;
        Debug.Log("username is: " +username);
    }
    public void getPassword()
    {
        password = GameObject.Find("passwordInput").GetComponent<Text>().text;
        Debug.Log("password is: " + password);
    }
    public void goHome()
    {
        SceneManager.LoadScene("WelcomePage");
    }

}
