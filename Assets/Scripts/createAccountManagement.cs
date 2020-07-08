using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.VersionControl;
using UnityEngine.Networking;
using System;

public class createAccountManagement : MonoBehaviour
{
    

    public InputField nameField;
    public  static InputField emailField;
    public InputField passwordField;
    public InputField confrimPassword;
    public InputField codeField;
    public Button submitButton;
    public Button confirmationButton;
    public Text consoleMessage;
    public Toggle showPasswordToggle;
    public static int confirmationCode;
    public GameObject inputConfirmationCode;


    
    public void CallRegister()
    {
        if (nameField.text.Length >= 8 && passwordField.text == confrimPassword.text && emailField.text.Contains("@") && emailField.text.Contains("."))
        {
            confirmationCode = UnityEngine.Random.Range(1000, 10000);
            Debug.Log(confirmationCode);
            StartCoroutine(Register());
        }
        else
        {
            consoleMessage.text = "Check your inputs";
            submitButton.interactable = false;
        }
            

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
            Emailer.Begin();
            inputConfirmationCode.SetActive(true);
            submitButton.interactable = false;
            confirmationButton.interactable = true;

            //Emailer emailObject = new Emailer();
            //emailObject.Start(emailField.text, confirmationCode);
            //verifyConfirmationCode();
                                                          

        }
        else
        {
            consoleMessage.text = "ooops: " + www.text;
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }
    public void verifyConfirmationCode()
    {
        if (int.Parse(codeField.text) != confirmationCode)
        {
            consoleMessage.text = "Wrong code";
            
        }
        else
        {
            SceneManager.LoadScene("WelcomePage");
        }
        //else return false;
    }

    public void verifyInputs()
    {
        if(nameField.text.Length >= 8 && passwordField.text == confrimPassword.text && emailField.text.Contains("@") && emailField.text.Contains("."))
        {
            submitButton.interactable = true;
        }
                
    }
    public void VerifyUsername()
    {
        if (nameField.text.Length >= 8)
        {
            consoleMessage.text = "";

        }
        else consoleMessage.text = "Enter a valid username";
    }
    public void VerifyPasswords()
    {
        if (confrimPassword.text == passwordField.text)
        {
            consoleMessage.text = "";
        }
        else consoleMessage.text = "Passwords dont match";
    }
    

    public void VerifyEmail()
    {
        if(emailField.text.Contains("@") && emailField.text.Contains("."))
        {

            consoleMessage.text = "";
        }
        else
        {
            consoleMessage.text = "Enter a valid email";
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


