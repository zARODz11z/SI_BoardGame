using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.VersionControl;
using UnityEngine.Networking;

public class createAccountManagement : MonoBehaviour
{
    

    public InputField nameField;
    public InputField emailField;
    public InputField passwordField;
    public InputField confrimPassword;
    public Button submitButton;
    public Text consoleMessage;
    public Toggle showPasswordToggle;


    
    public void CallRegister()
    {
        StartCoroutine(Register());

    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("email",emailField.text);
        form.AddField("password", passwordField.text);
        form.AddField("confirmPassword", confrimPassword.text);

        WWW www = new WWW("http://localhost:81/SI_BoardGame/register.php", form);

        yield return www;
        if (www.text == "0" && passwordField.text == confrimPassword.text)
        {
            Debug.Log("User created successfully");
            SceneManager.LoadScene("WelcomePage");

        }
        else
        {
            consoleMessage.text = "ooops: " + www.text;
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
    
    public void VerifyEmail()
    {
        if(emailField.text.Contains("@") && emailField.text.Contains("."))
        {
            submitButton.interactable = true;
            consoleMessage.text = "";
        }
        else
        {
            consoleMessage.text = "Please enter a valid email";
        }
        //submitButton.interactable = (emailField.text.Contains("@") && emailField.text.Contains("."));
    }
    
  
    public void hideOrShowPassword()
    {
        if (showPasswordToggle.isOn)
        {
            passwordField.contentType = InputField.ContentType.Standard;
            confrimPassword.contentType = InputField.ContentType.Standard;
        }
        else if (!showPasswordToggle.isOn)
        {
            passwordField.contentType = InputField.ContentType.Password;
            confrimPassword.contentType = InputField.ContentType.Password;
        }
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


