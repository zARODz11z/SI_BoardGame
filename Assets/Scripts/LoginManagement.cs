using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoginManagement : MonoBehaviour
{
    
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public Text consoleMessage;
    public Toggle showPasswordToggle;



    public void CallLogin()
    {
        StartCoroutine(Login());

    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        //WWW www = new WWW("http://localhost:81/SI_BoardGame/login.php", form);
        WWW www = new WWW("https://www.andrewthedev.com/UnityGames/SI_BoardGame/login.php", form);
        yield return www;
        Debug.Log(www.text);
        Debug.Log(www.text[0] == '0');
        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            //DBManager.score = int.Parse(www.text.Split('\t')[2]);
            SceneManager.LoadScene("WelcomePage");

        }
        else
        {
            consoleMessage.text = www.text;
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void hideOrShowPassword()
    {
        if (showPasswordToggle.isOn)
        {
            passwordField.contentType = InputField.ContentType.Standard;
            
        }
        else if (!showPasswordToggle.isOn)
        {
            passwordField.contentType = InputField.ContentType.Password;
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
    // Use this for initialization


    
    
    public void forgotPassword()
    {
        SceneManager.LoadScene("forgotPassword");
    }

       public void MuteToggle()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().mute;
    }
    
    public void goHome()
    {
        SceneManager.LoadScene("WelcomePage");
    }

}
